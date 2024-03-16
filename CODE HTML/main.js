function openFile(key) {
    document.getElementById("Upfile").click()
}
function loadImg(event){
    debugger
    const file = event.target.files[0]; // Get the first file selected by the user
      const reader = new FileReader();

      reader.onload = function(event) {
        debugger
        const fileContent = event.target.result; // Content of the file
        const blob = new Blob([fileContent], { type: file.type });
        const fileUrl = URL.createObjectURL(blob); // Create Blob URL
        fileUrlLink.href = fileUrl; // Set the link href to the Blob URL
        console.log(fileUrl)
      };

      reader.readAsArrayBuffer(file); // Read file a
  
}
document.getElementById("btnUpfile").addEventListener("click", function () {
    openFile("file")
});