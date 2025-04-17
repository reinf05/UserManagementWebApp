﻿//Declare all the constants that will be used
const searchForm = document.getElementById('searchForm');
const searchValue = document.getElementById('searchValue');
const tableData = document.getElementById('listUserData');
const searchText = document.getElementById('searchText');

const deleteUserData = document.getElementById('deleteUserData');
const deleteText = document.getElementById('deleteText');

const createForm = document.getElementById('createUserForm');
const createText = document.getElementById('createText');

//function to display all of the users
async function listAllUsers() {

    await fetch('/api/UsersApi')
        .then(result => result.json())
        .then(users => {
            users.forEach(user => {
                tableData.innerHTML +=
                    `<tr>
                    <td>${user.id}</td>
                    <td>${user.name}</td>
                    <td>${user.email}</td>
                    <td>${user.birthDate}</td>
                    <td>${user.registrationDate}</td>
                    <td>
                        <a href="${editUrl.replace('id', user.id)}">Edit</a>
                        <a href="${deleteUrl.replace('id', user.id) }" class="link-danger">Delete</a>
                    </td>
                </tr>`
            });
        })
        .catch(error => {
            console.log(error);
        })
}

//Function to display a specific user with given ID
async function getUserById(id) {
    await fetch(`/api/UsersApi/${id}`, {
        method:'GET'
    })
        .then(result => {
            if (result.status == 200) {
                return result.json()
            }
            else {
                return null;
            }
        })
        .then(user => {
            tableData.innerHTML = '';
            if (user != null) {
                searchText.innerText = 'Search was successful';
                tableData.innerHTML +=
                    `<tr>
                        <td>${user.id}</td>
                        <td>${user.name}</td>
                        <td>${user.email}</td>
                        <td>${user.birthDate}</td>
                        <td>${user.registrationDate}</td>
                        <td>
                            <a href="${editUrl.replace('id', user.id)}">Edit</a>
                            <a href="${deleteUrl.replace('id', user.id) }" class="link-danger">Delete</a>
                        </td>
                    </tr>`
            }
            else {
                searchText.innerText = 'Search was not successful';
                listAllUsers();
            }
        })
        .catch(error => {
            console.log(error)
        })
}

//Function to delete a user

//Function to create users
async function CreateUser() {
    const createName = document.getElementById('createName').value; 
    const createEmail = document.getElementById('createEmail').value;
    const createBirthDate = document.getElementById('createBirthDate').value;

    if (createName != '' && createEmail != '' && createBirthDate !== '') {
        const createUserDto = {
            name: createName,
            email: createEmail,
            birthDate: createBirthDate
        }

        await fetch('/api/UsersApi', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(createUserDto)
            }).then(result => {
                if (result.status == 409) {
                    createText.innerText = "User already exists with this email. Please provide an other one";
                }
                else if (result.status == 200) {
                    window.location.href = '/Users/List'
                }
            })
            .catch(error => {
                console.log(error)
            })
    }
    else {
        alert('Please fill out all of the field accordingly')
    }

};


//Event listeners
//If search page is loaded, load all of the users
document.addEventListener('DOMContentLoaded', event => {
    event.preventDefault();
    switch (currentAction) {
        case "List":
            listAllUsers();
            break;
        case "Edit":
            //edit function
            break;
        case "Delete":
            break;
    }
});

//if search button is available (search page is loaded)
if (searchForm) {
    //If a click 
    searchForm.addEventListener('submit', event => {
        event.preventDefault();
        const inputValue = searchValue.value.trim();
        //Although input type number only accepts number, nothing still can be inputted
        //That is why this check is necessary
        if (inputValue !== '') {
            getUserById(inputValue);
        }
        else if (inputValue <= 0) {
            alert('ID must be a positive number')
        }
        else {
            alert('Please enter a number to search');
        }
    })
}

//If create btn clicked
if (createForm) {
    createForm.addEventListener('submit', event => {
        event.preventDefault();
        CreateUser();
    })
}