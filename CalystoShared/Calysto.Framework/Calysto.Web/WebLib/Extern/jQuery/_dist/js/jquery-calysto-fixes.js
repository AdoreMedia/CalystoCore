if (window.$ && $.validator && $.validator.unobtrusive)
{
    /****************************************************************
     * jquery.validate.js fixes
     * **************************************************************/
    /**
     * original code invokes element() every time on keyup and similar event.
     * fix: invoke complete form validation to update summary description.
     * @param {any} element
     */
    $.validator.prototype.element = function (element)
    {
        this.form();
    };

    /** rename base method */
    $.validator.prototype.defaultShowErrorsBase = $.validator.prototype.defaultShowErrors;

    /** fix: updated method to update summary element every time when element is validated */
    $.validator.prototype.defaultShowErrors = function ()
    {
        this.defaultShowErrorsBase();

        // this updates summary description
        // original function doesn't update summary if there is no error element (eg. update from 1 error to 0 will leave summary with previous error)
        // method has to be updated in jquery.validate.unobtrusive.js
        //$(this.currentForm).triggerHandler("invalid-form", [this]);
        this.updateSummaryMessages.call(this.currentForm, null, this);
    };

    /****************************************************************
     * jquery.validate.unobtrusive.js fixes
     * **************************************************************/

    $.validator.prototype.updateSummaryMessages = function (event, validator)
    {
        // 'this' is the form element
        var container = $(this).find("[data-valmsg-summary=true]"),
            list = container.find("ul");

        list.empty(); // fix: delete "li" items before adding new

        if (list && list.length && validator.errorList.length)
        {
            // list.empty(); // fix: not required here
            container.addClass("validation-summary-errors").removeClass("validation-summary-valid");

            $.each(validator.errorList, function ()
            {
                $("<li />").html(this.message).appendTo(list);
            });
        }
    }
}