// Function to toggle visibility of subcategories
function toggleSubcategories(subcategoryId, iconId) {
    const subcategoryDiv = document.getElementById(subcategoryId);
    const toggleIcon = document.getElementById(iconId);
    
    // Toggle subcategories visibility
    if (subcategoryDiv.style.display === "none" || subcategoryDiv.style.display === "") {
        subcategoryDiv.style.display = "block";
        toggleIcon.innerHTML = "&#9660;"; // Down arrow
    } else {
        subcategoryDiv.style.display = "none";
        toggleIcon.innerHTML = "&#8250;"; // Right arrow
    }
}

// Function to sync subcategory checkboxes with the industry checkbox
function syncSubcategories(subcategoryId, industryCheckbox) {
    const subcategoryDiv = document.getElementById(subcategoryId);
    const subcategoryCheckboxes = subcategoryDiv.getElementsByClassName("subcategory-checkbox");

    // Toggle subcategories and their checkboxes based on the industry checkbox state
    if (industryCheckbox.checked) {
        subcategoryDiv.style.display = "block";
        Array.from(subcategoryCheckboxes).forEach(checkbox => checkbox.checked = true);
    } else {
        subcategoryDiv.style.display = "none";
        Array.from(subcategoryCheckboxes).forEach(checkbox => checkbox.checked = false);
    }
}


// Function to toggle a checkbox based on its associated label click
function toggleCheckbox(checkboxId) {
    const checkbox = document.getElementById(checkboxId);
    checkbox.checked = !checkbox.checked;
}

// Function to filter departments
function filterIndustries() {
    const searchInput = document.getElementById("industrySearch").value.toLowerCase();
    const industries = document.getElementsByClassName("industry");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}



// Function to filter industries 
function filterIndustries2() {
    const searchInput = document.getElementById("industrySearch2").value.toLowerCase();
    const industries = document.getElementsByClassName("industry2");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}


// Function to filter Revenue
function filterIndustries3() {
    const searchInput = document.getElementById("industrySearch3").value.toLowerCase();
    const industries = document.getElementsByClassName("industry3");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}


// Function to filter company sizes
function filterIndustries4() {
    const searchInput = document.getElementById("industrySearch4").value.toLowerCase();
    const industries = document.getElementsByClassName("industry4");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}


// Function to filter Level
function filterIndustries5() {
    const searchInput = document.getElementById("industrySearch5").value.toLowerCase();
    const industries = document.getElementsByClassName("industry5");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}

function filterIndustries6() {
    const searchInput = document.getElementById("industrySearch6").value.toLowerCase();
    const industries = document.getElementsByClassName("industry6");

    for (let i = 0; i < industries.length; i++) {
        const industry = industries[i];
        const industryLabel = industry.getElementsByTagName("label")[0].innerHTML.toLowerCase();
        const subcategories = industry.getElementsByClassName("subcategories")[0];
        const subcategoryLabels = subcategories.getElementsByTagName("label");

        let isMatch = false;

        // Check if the industry title matches the search input
        if (industryLabel.indexOf(searchInput) > -1) {
            isMatch = true;
        }

        // Check if any of the subcategory labels match the search input
        for (let j = 0; j < subcategoryLabels.length; j++) {
            const subcategoryLabel = subcategoryLabels[j].innerHTML.toLowerCase();
            if (subcategoryLabel.indexOf(searchInput) > -1) {
                isMatch = true;
                // Automatically show subcategories if a match is found
                subcategories.style.display = "block";
                industry.getElementsByTagName("input")[0].checked = true; // Check the industry checkbox
                document.getElementById(industry.getElementsByTagName("input")[0].id + "ToggleIcon").innerHTML = "&#9660;"; // Change icon to down arrow
                break;
            }
        }

        // Display the industry (and its subcategories) if a match is found
        if (isMatch) {
            industry.style.display = "";
        } else {
            industry.style.display = "none";
            industry.getElementsByTagName("input")[0].checked = false; // Uncheck the industry checkbox
        }
    }
}

// Function to show the dropdown content
function showDropdown() {
    const dropdownContent = document.getElementById("dropdownContent");
    dropdownContent.style.display = "block"; // Show the dropdown content when search bar is clicked
}

function showDropdown2() {
    const dropdownContent2 = document.getElementById("dropdownContent2");
    dropdownContent2.style.display = "block"; // Show the dropdown content when search bar is clicked
}

function showDropdown3() {
    const dropdownContent3 = document.getElementById("dropdownContent3");
    dropdownContent3.style.display = "block"; // Show the dropdown content when search bar is clicked
}

function showDropdown4() {
    const dropdownContent4 = document.getElementById("dropdownContent4");
    dropdownContent4.style.display = "block"; // Show the dropdown content when search bar is clicked
}

function showDropdown5() {
    const dropdownContent5 = document.getElementById("dropdownContent5");
    dropdownContent5.style.display = "block"; // Show the dropdown content when search bar is clicked
}

function showDropdown6() {
    const dropdownContent6 = document.getElementById("dropdownContent6");
    dropdownContent6.style.display = "block"; // Show the dropdown content when search bar is clicked
}


// Function to hide the dropdown content when clicking outside
function hideDropdown(event) {
    const dropdownContent = document.getElementById("dropdownContent");
    const dropdownContent2 = document.getElementById("dropdownContent2");
    const dropdownContent3 = document.getElementById("dropdownContent3");
    const dropdownContent4 = document.getElementById("dropdownContent4");
    const dropdownContent5 = document.getElementById("dropdownContent5");
    const dropdownContent6 = document.getElementById("dropdownContent6");

    const searchBar = document.getElementById("industrySearch");
    const searchBar2 = document.getElementById("industrySearch2");
    const searchBar3 = document.getElementById("industrySearch3");
    const searchBar4 = document.getElementById("industrySearch4");
    const searchBar5 = document.getElementById("industrySearch5");
    const searchBar6 = document.getElementById("industrySearch6");


    // Check if the click target is outside the dropdown and search bar
    if (!dropdownContent.contains(event.target) && !searchBar.contains(event.target)) {
        dropdownContent.style.display = "none";
    }

    if (!dropdownContent2.contains(event.target) && !searchBar2.contains(event.target)) {
        dropdownContent2.style.display = "none";
    }

    if (!dropdownContent3.contains(event.target) && !searchBar3.contains(event.target)) {
        dropdownContent3.style.display = "none";
    }

    if (!dropdownContent4.contains(event.target) && !searchBar4.contains(event.target)) {
        dropdownContent4.style.display = "none";
    }


    if (!dropdownContent5.contains(event.target) && !searchBar5.contains(event.target)) {
        dropdownContent5.style.display = "none";
    }

    if (!dropdownContent6.contains(event.target) && !searchBar6.contains(event.target)) {
        dropdownContent6.style.display = "none";
    }
}



// Add event listener to the document to detect clicks outside the dropdown
document.addEventListener("click", function(event) {
    hideDropdown(event);

});





