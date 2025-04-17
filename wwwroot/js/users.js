const searchForm = document.getElementById('searchForm');
const searchBtn = document.getElementById('searchBtn');

function listAllUsers() {
    const tableData = document.getElementById('listUserData');

    fetch('/api/UsersApi')
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
                </tr>`
            });
        })
        .catch(error => {
            console.log(error);
        })
}

document.addEventListener('DOMContentLoaded', event => {
    event.preventDefault();
    listAllUsers();
});
