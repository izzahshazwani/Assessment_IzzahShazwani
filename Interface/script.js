document.addEventListener("DOMContentLoaded", function () {
    const userForm = document.getElementById("userForm");
    const message = document.getElementById("message");

    userForm.addEventListener("submit", function (e) {
        e.preventDefault();
        const formData = new FormData(userForm);
        const userData = {};
        formData.forEach((value, key) => {
            userData[key] = value;
        });

        // Send a POST request to the API to register a new user
        fetch("/api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(userData),
        })
            .then((response) => response.json())
            .then((data) => {
                message.textContent = "User registered successfully!";
                message.style.color = "green";
                message.style.display = "block";
            })
            .catch((error) => {
                message.textContent = "Error: " + error.message;
                message.style.color = "red";
                message.style.display = "block";
            });
    });
});