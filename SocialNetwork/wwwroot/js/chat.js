"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

function updateScroll() {
    var messages = document.getElementById("messagesList");
    messages.scrollTop = messages.scrollHeight;
}

connection.on("ReceiveMessage", function (username, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = username + " says: " + msg;
    var li = document.createElement("li");
    var br = document.createElement("br");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    document.getElementById("messagesList").appendChild(br);
    updateScroll();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {3
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var username = username
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", username, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});