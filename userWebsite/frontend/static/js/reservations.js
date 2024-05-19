function init() {
    document.getElementById("userCreationForm").style.display = "none";

}



function showFormFace() {
    alert("")
    var faceAddForm = document.getElementById("addFaceForm");
    if (faceAddForm.style.display === "block") {
        faceAddForm.style.display = "none"; // Hide the form
    } else {
        faceAddForm.style.display = "block"; // Show the form
    }
}

function showForm() {
    var userCreationForm = document.getElementById("userCreationForm");
    if (userCreationForm.style.display === "block") {
        userCreationForm.style.display = "none"; // Hide the form
    } else {
        userCreationForm.style.display = "block"; // Show the form
    }
}


function groupPairs(array) {
    const pairs = [];
    for (let i = 0; i < array.length; i += 2) {
        if (i + 1 < array.length) {
            pairs.push([array[i], array[i + 1]]);
        } else {
            pairs.push([array[i]]);
        }
    }
    return pairs;
}



function updateDateTime() {
    const now = new Date();
    const dateTimeString = now.toLocaleString();
    const footerElement = document.querySelector("footer p");
    footerElement.textContent = `${dateTimeString}`;
}

setInterval(updateDateTime, 1000);