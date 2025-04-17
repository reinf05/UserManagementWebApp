//If search page is loaded, load all of the users
document.addEventListener('DOMContentLoaded', event => {
    event.preventDefault();
    if (currentAction == "List") {
            listAllUsers();
    }
});