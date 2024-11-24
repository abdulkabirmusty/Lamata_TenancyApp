const loginButton = document.getElementById("loginButton");
const registerButton = document.getElementById("registerButton");
const loginForm = document.getElementById("loginForm");
const registerForm = document.getElementById("registerForm");
const partialContainer = document.getElementById("partialContainer");
const paymentModal = document.getElementById("paymentModal")

registerButton.addEventListener("click", function() {
  loginForm.style.display = "none";
  registerForm.style.display = "block";
  loginButton.style.color = "#a0a0a0";
   registerButton.style.color = "#c6202f";
  loginButton.style.borderBottom = "2px solid #a0a0a0";
  registerButton.style.borderBottom = "4px solid #c6202f";
});

loginButton.addEventListener("click", function() {
  registerForm.style.display = "none";
  loginForm.style.display = "block";
  loginButton.style.color = "#c6202f";
  registerButton.style.color = "#a0a0a0";
  loginButton.style.borderBottom = "4px solid #c6202f";
  registerButton.style.borderBottom =  "2px solid #a0a0a0"  ;
});

function toggleAddDepartment() {

    if (partialContainer.style.display === "none") {
        partialContainer.style.display = "block";
    } else {
        partialContainer.style.display = "none";
    }
}
function makePayment() {
    if (paymentModal.style.display === "none") {
        paymentModal.style.display = "flex";
    } else {
       paymentModal.style.display = "none";
    }
}
function handleCheckboxChange(checkbox) {
    if (checkbox.checked) {
        // close modal
        makePayment()
      // route to another page
      window.location.href = "./dashboard.html";
    }
}