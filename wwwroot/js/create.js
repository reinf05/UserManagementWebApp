//Declare constants
const createForm = document.getElementById('createUserForm');
const createText = document.getElementById('createText');

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

//If create btn clicked
createForm.addEventListener('submit', event => {
    event.preventDefault();
    CreateUser();
})