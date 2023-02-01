const eHints = document.getElementById("hints");

function reset() {

}

function createUser() {

}

function login() {
    let username = document.getElementById("username");
    let password = document.getElementById("password");
    presenceCheck(username, "Enter a valid username");
    presenceCheck(password, "Enter a valid password");
    eHints.innerText = "Attempting login..."
    lengthCheck(password, 8, 12, "Please enter a passowrd between 8 and 12 characters")
}

function presenceCheck(input, message) {

    if (input == "") {
        eHints.innerText = message;
        throw message;
    }
}

function lengthCheck(input, minLength, maxLength, message) {
    if (input.length > maxLength || input.length < minLength) {
        eHints.innerText = message;
        throw message;
    }
}