const yearSpan = document.querySelector(".footer-year");
const postalInput = document.querySelector(".postalcode")
const shipBtn = document.querySelector(".ship-btn")
const closePopupBtn = document.querySelector(".close-popup")
const popup = document.querySelector(".popup")
const city = document.querySelector(".city")
const street = document.querySelector(".street")
const errors = document.querySelectorAll(".error")
const shipInputs = document.querySelectorAll(".ship-adress")

let year = new Date().getFullYear();

yearSpan.textContent = year;

let regex = /\d/
let errorCount = 0;

const inputFilter = (event, regEx) => {
    let key = event.keyCode
    let code = postalInput.value

    let symbol = String.fromCharCode(event.keyCode)

    if (!regEx.test(symbol)) {
        event.preventDefault();
    }
    

    if (postalInput.value.length != 2) {
        return
    }

    if (key != 8 || key != 46) {
        postalInput.value = code + "-"
    }

};

const inputEvent = (event) => {
    inputFilter(event, regex);
};

const showError = (input) => {
    const errorP = input.previousElementSibling 

    errorP.classList.add("show-error")
};

const clearError = (input) => {
    const errorP = input.previousElementSibling
    errorP.classList.remove("show-error");
};

const checkForm = (input) => {
    input.forEach((el) => {
        if (el.value === "") {
            showError(el);
        } else {
            clearError(el);
        }
    });
};

//const checkLength = (input) => {
//    if (input.value.length < 6) {
//        showError(input)
//    }
//}

shipBtn.addEventListener("click", (e) => {
    e.preventDefault();
    checkForm([city, street, postalInput]);
    //checkLength(postalInput)

    errorCount = 0;

    errors.forEach(el => {
        if (el.classList.contains("show-error")) {
            errorCount++
        }
    })

    if (errorCount === 0) {
        popup.style.display = "block"
    }
})
closePopupBtn.addEventListener("click", () => {
    popup.style.display = "none";
})

shipInputs.forEach(el => {
    el.addEventListener("keypress", () => {
        checkForm([city, street, postalInput]);
    })
})

postalInput.addEventListener('keypress', inputEvent);