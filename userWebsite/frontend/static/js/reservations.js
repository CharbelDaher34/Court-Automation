function init() {
    document.getElementById("userCreationForm").style.display = "none";
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

function checkAvailability() {
    var startTime = document.getElementById("startTime").value;
    var endTime = document.getElementById("endTime").value;
    let available_slots = document.getElementById("slots").value;
    // Convert startTime and endTime to integers
    let [hours, minutes] = startTime.split(":");
    let startHour = parseInt(hours);
    let startMin = (parseInt(minutes)[(hours, minutes)] = endTime.split(":"));
    let endHour = parseInt(hours);
    let endMin = parseInt(minutes);

    // Convert available_slots to a list of tuples of integers
    let stringData = available_slots.replace(/\[|\]|\(/g, "");
    let dataArray = stringData.replace(/'/g, "").split("),");
    dataArray = dataArray.map((item) => item.trim());
    parts = dataArray[0].split(",").map((part) => part.trim());
    available_slots = parts.map((part) => {
        let [hour, minute] = part.split(":").map((num) => parseInt(num));
        return [hour, minute];
    });

    available_slots = groupPairs(available_slots);
    let isAvailable = false; // Initialize availability flag to false

    for (let i = 0; i < available_slots.length; i = i + 1) {
        let slot = available_slots[i];

        let slotStartHour = slot[0][0];
        let slotStartMin = slot[0][1];
        let slotEndHour = slot[1][0];
        let slotEndMin = slot[1][1];

        // Check if start time falls within the current available slot
        if (
            (startHour > slotStartHour ||
                (startHour === slotStartHour && startMin >= slotStartMin)) &&
            // Check if end time also falls within the current available slot
            (endHour < slotEndHour ||
                (endHour === slotEndHour && endMin <= slotEndMin))
        ) {
            isAvailable = true; // Slot found, set flag to true
            break; // Exit the loop once a slot is found
        } else {
            // No match, continue checking other slots
        }
    }

    var courtSectionId = "{{ court_section.courtSectionId }}";
    var date = "{{ date }}";

    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    var requestData = {
        email: email,
        password: password,
        courtSectionId: courtSectionId,
        startTime: startTime,
        endTime: endTime,
        date: date,
    };
    alert(requestData);
    fetch(
        "http://localhost:8000/frontend/reserve_court_section/" +
        courtSectionId +
        "/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(requestData),
        }
    ).then((response) => {
        if (response.ok) {
            fetch("http://localhost:8000/frontend/home/", {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                },
            });

            alert("Reservation successfully!");
        } else if (response.status === 404) {
            alert("Client not found");
        } else if (response.status === 401) {
            alert("Incorrect password");
        }
    });
}

function updateDateTime() {
    const now = new Date();
    const dateTimeString = now.toLocaleString();
    const footerElement = document.querySelector("footer p");
    footerElement.textContent = `${dateTimeString}`;
}

setInterval(updateDateTime, 1000);