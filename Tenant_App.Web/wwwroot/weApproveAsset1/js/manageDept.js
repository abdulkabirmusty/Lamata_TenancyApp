function toggleAddDeptModal() {
  console.log("toggled");
  if (
    document.getElementById("newDeptModalcontainer").style.display === "none"
  ) {
    document.getElementById("newDeptModalcontainer").style.display = "flex";
  } else {
    document.getElementById("newDeptModalcontainer").style.display = "none";
  }
}
document
    .getElementById("addDeptClose").addEventListener("click", toggleAddDeptModal);
document
  .getElementById("addDeptModalOpen")
  .addEventListener("click", toggleAddDeptModal);