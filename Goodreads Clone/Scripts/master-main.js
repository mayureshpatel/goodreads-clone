$(document).ready(function () {
    var navSearchForm = $("#nav-search-form");
    var navUL = $("#nav-ul");
    var cancelButton = $("#resetSearchButton");

    // When the search button is clicked, toggle the search bar only if the document width is 576px or less
    $("#searchBookButton").click(function () {
        var windowSize = $(window).width();

        if (windowSize <= 576) {
            // toggle the form
            navSearchForm.toggle();

            // toggle the nav
            navUL.toggle();

            // change the values of the logo to the gotten value
            var displayOutput = navSearchForm.css("display")

            // change the display value to flex if it is block
            if (displayOutput.localeCompare("block") == 0) {
                navSearchForm.css({ "display": "flex" });
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
            navUL.toggle();
        }
    });

    // When the cancel button is clicked, toggle the search bar off and toggle the nav ul back on
    $(cancelButton).click(function () {
        // toggle the form
        navSearchForm.toggle();

        // toggle the nav
        navUL.toggle();
    });
});