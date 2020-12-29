$(document).ready(function () {
    var navSearchForm = $("#nav-search-form");
    var navUL = $("#nav-ul");
    var cancelButton = $("#ResetSearchButton");
    var browseButton = $("#BrowseButton");
    var browseDropDown = $("#BrowseDropDown");

    // When the search button is clicked, toggle the search bar only if the document width is 576px or less
    $("#searchBookButton").click(function () {
        var windowSize = $(window).width();

        if (windowSize <= 576) {
            // when the button is clicked and the form is not up, we want to make the ul disappear and the form appear
            if (navSearchForm.css("display").localeCompare("none") == 0) {
                // toggle the navbar off first immediately
                navUL.hide();

                // now slide down the search form
                navSearchForm.slideDown(150);

                // change the values of the logo to the gotten value
                var displayOutput = navSearchForm.css("display");

                // change the display value to flex if it is block
                if (displayOutput.localeCompare("block") == 0) {
                    navSearchForm.css({ "display": "flex" });
                }
            }
            else if (navSearchForm.css("display").localeCompare("flex") == 0) {
                // toggle the searchbar off first immediately
                navSearchForm.hide();

                // now slide down the nav ul
                navUL.slideDown(150);
            }
        }
    });

    // Need to handle when the toggle search bar is up and the window is resized to greater than 576px
    $(window).resize(function () {
        var windowSize = $(window).width();

        if (windowSize > 576 && navSearchForm.css("display").localeCompare("flex") == 0) {
            // toggle the form
            navSearchForm.toggle();

            // toggle the nav
            navUL.slideToggle(350);
        }
    });

    // When the cancel button is clicked, toggle the search bar off and toggle the nav ul back on
    $(cancelButton).click(function () {
        // toggle the form
        navSearchForm.toggle();

        // toggle the nav
        navUL.toggle(250);
    });

    // When the browse button is clicked, toggle the browse dropdown menu
    $(browseButton).click(function () {
        // toggle the browse drop down
        browseDropDown.slideToggle(150);

        // change the values of the logo to the gotten value
        var displayOutput = browseDropDown.css("display");

        // change the display value to flex if it is block
        if (displayOutput.localeCompare("block") == 0) {
            browseDropDown.css({ "display": "grid" });
        }
    });

    // Be able to click anywhere to hide the Browse drop down
    $("body").click(function (evt) {
        if (evt.target.id == "#BrowseDropDown") {
            console.log("nope 1");
            return;
        }
            
        //For descendants of menu_content being clicked, remove this check if you do not want to put constraint on descendants.
        if ($(evt.target).closest("#BrowseDropDown").length) {
            console.log("nope 2");
            return;
        }

        //Do processing of click event here for every element except with id menu_content
        if (evt.target.id == "" && browseDropDown.css("display").localeCompare("grid") == 0) {
            browseDropDown.slideToggle(150);
        }
    });
});