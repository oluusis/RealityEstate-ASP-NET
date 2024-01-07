document.addEventListener("DOMContentLoaded", function () {
    var addButton = document.getElementById("addImageButton");
    var fileInputsContainer = document.getElementById("fileInputsContainer");

    addButton.addEventListener("click", function () {
        var newFileInput = document.createElement("div");
        newFileInput.innerHTML = `
                <label for="formfile">Upload Image:</label>
                <input type="file" name="formfile" class="formfile">
            `;
        fileInputsContainer.appendChild(newFileInput);
    });
});