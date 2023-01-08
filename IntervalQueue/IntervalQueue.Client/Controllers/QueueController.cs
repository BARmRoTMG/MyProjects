using IntervalQueue.Client.Models;
using IntervalQueue.Data.Entities;
using IntervalQueue.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntervalQueue.Client.Controllers
{
    public class QueueController : Controller
    {
        private readonly IRepository<Customer> _context;
        private readonly IMapper<Customer, CustomerDto> _mapper;

        Queue<Customer> _queue = new Queue<Customer>();

        public QueueController(IRepository<Customer> context, IMapper<Customer, CustomerDto> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private void UpdateQueue() //Enter any existing data to the queue.
        {
            var customers = _context.GetAll();

            foreach (var customer in customers)
            {
                _queue.Enqueue(customer);
            }
        }

        public IActionResult Index()
        {
            UpdateQueue();

            ViewData.Add("QueueEntry", new CustomerDto());
            ViewData.Add("QueueList", _queue.Select(c => _mapper.Map(c)));
            if (_queue.Count > 0)
            {
                ViewData.Add("CurrentCustomer", _mapper.Map(_context.Get(_queue.Peek().Id))); //Getting id of first customer inserted to queue
                ViewBag.EnteredAtTime = DateTime.Now.ToString("HH:mm");
            }
            else
                ViewBag.ErrorMessage = "No more people are waiting!";

            return View();
        }

        [HttpPost]
        public IActionResult AddQueueEntry(string name)
        {
            var newCustomer = new Customer
            {
                Name = name,
                EntryTime = DateTime.Now.TimeOfDay,
                SerialNumber = new Random().Next(100, 1000)
            };

            _context.Add(newCustomer); //Enter new queue to database
            _queue.Enqueue(newCustomer); //Enter new queue to local queue list.
            UpdateQueue();

            return RedirectToAction("Index");
        }

        public IActionResult CallNext()
        {
            UpdateQueue();

            if (_queue.Count > 0)
            {
                _context.Delete(_queue.Dequeue().Id); //Removes and after returns first
                ViewBag.EnteredAtTime = DateTime.Now.ToString("HH:mm");
            }

            return RedirectToAction("Index");
        }
    }
}
