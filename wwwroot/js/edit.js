//Declare constants
const editForm = document.getElementById('editUserForm');

//Function to edit the user
async function UpdateUser(id) {
    const editName = document.getElementById('editName').value;
    const editEmail = document.getElementById('editEmail').value;
    const editBirthDate = document.getElementById('editBithDate').value;

    const editUserDto = {
        id: currentId,
        name: editName,
        email: editEmail,
        birthDate: editBirthDate
    }

    fetch(`/api/UsersApi/${id}`, {
        method: 'PUT',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(editUserDto)
    }).then(result => {
        if (result.status == 404) {
            alert('User not found');
        } else if (result.status == 204) {
            alert('User successfully edited');
            window.location.href = '/Users/List'
        } else {
            alert('Something went wront, please try again')
        }
    })
}

//If edit btn clicked
if (editForm) {
    editForm.addEventListener('submit', event => {
        event.preventDefault();
        UpdateUser(currentId);
    })
}
