const newstaffmodaldropdownToggle = document.querySelector(
  "#newstaffmodaldropdown-toggle"
);
const newstaffmodaldropdownMenu = document.querySelector(
  ".newstaffmodaldropdown-menu"
);
const newstaffmodaldropdownItems = document.querySelectorAll(
  ".newstaffmodaldropdown-item"
);
const newstaffmodaloptions = document.querySelector(".newstaffmodaloptions");
const newstaffmodalstatus = document.querySelector(".newstaffmodalstatus");

newstaffmodaldropdownToggle.addEventListener("click", function () {
  newstaffmodaldropdownMenu.style.display =
    newstaffmodaldropdownMenu.style.display === "block" ? "none" : "block";
});

newstaffmodaldropdownItems.forEach((newstaffmodaldropdown) => {
  newstaffmodaldropdown.addEventListener("click", () => {
    newstaffmodalstatus.innerHTML = newstaffmodaloptions.innerHTML;
    newstaffmodaldropdownMenu.style.display =
      newstaffmodaldropdownMenu.style.display === "block" ? "none" : "block";
  });
});

function toggleUploadStaffModal() {
  console.log("toggled");
  if (document.getElementById("uploadStaffModal").style.display === "block") {
    document.getElementById("uploadStaffModal").style.display = "none";
  } else {
    document.getElementById("uploadStaffModal").style.display = "block";
  }
}

document
  .getElementById("closeUploadStaffModal")
    .addEventListener("click", toggleUploadStaffModal);
  
document
  .getElementById("uploadStaffbtn")
  .addEventListener("click", toggleUploadStaffModal);
  

function toggleAddStaffModal() {
  console.log("toggled");
  if (
    document.getElementById("newStaffModalcontainer").style.display === "none"
  ) {
    document.getElementById("newStaffModalcontainer").style.display = "flex";
  } else {
    document.getElementById("newStaffModalcontainer").style.display = "none";
  }
}
document
  .getElementById("newStaffModalClose")
  .addEventListener("click", toggleAddStaffModal);
document
  .getElementById("addStaffbtn")
  .addEventListener("click", toggleAddStaffModal);


