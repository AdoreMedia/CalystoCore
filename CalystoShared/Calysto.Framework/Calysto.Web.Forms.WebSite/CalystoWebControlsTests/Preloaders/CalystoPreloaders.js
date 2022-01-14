var CalystoPreloaders;
(function (CalystoPreloaders) {
    function AppendItem(name, svg) {
        $$calysto(["#divContainer1", "#divContainer2", "#divContainer3"])
            .AddChildren("\n<div class=\"spinnerItem\">\n\t<div class=\"spinnerLabel\">".concat(name, "</div>\n\t<div class=\"svgContainer\">").concat(svg, "</div>\n</div>\n"));
    }
    Calysto.Page.OnInteractive(function () {
        for (var prop in Calysto.Preloaders) {
            var fn1 = Calysto.Preloaders[prop];
            if (typeof fn1 == "function") {
                AppendItem(prop, fn1());
            }
        }
    });
})(CalystoPreloaders || (CalystoPreloaders = {}));
//# sourceMappingURL=CalystoPreloaders.js.map