// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openFile(key) {
    if (key == "file") {
        document.getElementById("inputFile").click()
    }
    else {
        document.getElementById("inputImg").click()
    }
}
document.getElementById("btnUpfile").addEventListener("click", function () {
    openFile("file")
});

function loadNameFile(event) {
    var file = event.target.files[0].type;
    var file = event.target.files[0].type;
    if (file == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") {
        document.getElementById("viewFileName").innerHTML = event.target.files[0].name
    }
    else {
        document.getElementById("inputFile").value = null;
        alert("Chỉ Được Chọn File Doc");
    }

}
document.getElementById("deleteFile").addEventListener("click", function () {
    var input = document.getElementById("inputFile");
    input.value = null;
    document.getElementById("viewFileName").innerHTML = "";
})

document.getElementById("btnImgfile").addEventListener("click", function () {
    openFile("img")
});

function loadImgFile(event) {
    var file = event.target.files[0].type;
    if (file == "image/png" || file == "image/jpeg") {
        document.getElementById("viewImgName").innerHTML = event.target.files[0].name
    }
    else {
        document.getElementById("inputImg").value = null;
        alert("Chỉ Được Chọn File Hình Có Đuôi png,jpeg");  
    }
}
document.getElementById("deleteImg").addEventListener("click", function () {
    var input = document.getElementById("inputImg");
    input.value = null;
    document.getElementById("viewImgName").innerHTML = "";
})