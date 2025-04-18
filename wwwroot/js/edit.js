//Declare constants
const editForm = document.getElementById('editUserForm');
const currentId = document.getElementById('editId').innerText;

//Function to edit the user
async function UpdateUser(id) {
    const editName = document.getElementById('editName').value;
    const editEmail = document.getElementById('editEmail').value;
    const editBirthDate = document.getElementById('editBithDate').value;

    const editUser = {
        id: currentId,
        name: editName,
        email: editEmail,
        birthDate: editBirthDate,
        registrationDate: currentRegDate
    }

    fetch(`/api/UsersApi/${id}`, {
        method: 'PUT',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(editUser)
    }).then(result => {
        if (result.status == 404) {
            alert('User not found');
        } else if (result.status == 204) {
            alert('User successfully edited');
            window.location.href = '/Users/List'
        } else {
            alert('Something went wrong, please try again')
        }
    })
}

//If edit btn clicked
editForm.addEventListener('submit', event => {
    event.preventDefault();
    UpdateUser(currentId);
})
