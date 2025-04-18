//Declare constants
const deleteUserData = document.getElementById('deleteUserData');
const deleteText = document.getElementById('deleteText');
const deleteForm = document.getElementById('deleteUserForm');

//Function to delete a user
async function DeleteUser(id) {
    fetch(`/api/UsersApi/${id}`, {
        method: 'DELETE'
    }).then(result => {
        if (result.status == 404) {
            alert('User not found')
        }
        else if (result.status == 204) {
            alert('User successfully deleted')
            window.location.href = '/Users/List'
        }
        else {
            alert(result.status)
        }
    })
}

//If delete btn clicked
deleteForm.addEventListener('submit', event => {
    event.preventDefault();
    DeleteUser(currentId);
})