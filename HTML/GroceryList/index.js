function CheckInput(name, price){

    const addBtn = document.getElementById('addBtn');

    if (name.length > 0 && price > 0) {
        addBtn.disabled = false;
    } else {
        addBtn.disabled = true;
    }
}

function AddItem(name, price){
    const myTable = document.getElementById("myTable");
    const tableRow = document.createElement("tr");
    const tdName = document.createElement("td");
    const tdPrice = document.createElement("td");
    const tdDelete = document.createElement("td");
    const tdCheckBox = document.createElement("td");

    const deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Remove";
    deleteBtn.addEventListener('click',()=> tableRow.remove());
    deleteBtn.classList.add('remove-btn');

    const checkBox = document.createElement("input");
    checkBox.type = 'checkbox';
    checkBox.classList.add('check-green')

    tdName.innerHTML = name;
    tdPrice.innerHTML = price;
    tdDelete.appendChild(deleteBtn);
    tdCheckBox.appendChild(checkBox);

    tableRow.appendChild(tdName);
    tableRow.appendChild(tdPrice);
    tableRow.appendChild(tdDelete);
    tableRow.appendChild(tdCheckBox);

    myTable.appendChild(tableRow);
}