// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const filter = document.querySelector('#filters h1');

const formItems = document.querySelectorAll('#filters form *');

Show();

console.log(formItems);

filter.addEventListener('click', () => {
    filter.nextElementSibling.classList.toggle('dropdown');
    Show();
})


function Show() {
    formItems.forEach((a) => {
        a.classList.toggle('unvisible');
    })
}