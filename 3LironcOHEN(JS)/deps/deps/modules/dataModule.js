const data = [
  { id: 1, name: 'Liron' },
  { id: 2, name: 'Mirit' },
  { id: 3, name: 'Gili' },
  { id: 4, name: 'Ayala' },
  { id: 5, name: 'Daniella' },
  { id: 6, name: 'Yuval' }
];

const minAge = 18;

const name = 'Liron';

const whatIsMyName = () => {
  console.log(name);
}

// module export using manifest
export { data as default, minAge, whatIsMyName };