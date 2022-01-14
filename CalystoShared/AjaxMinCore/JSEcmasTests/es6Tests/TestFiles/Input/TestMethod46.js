
                
        function Oval(color = "black", backColor = "gainsboro", rotateCCV = false) {
            return `<svg viewBox="0 0 57 57" xmlns="http://www.w3.org/2000/svg" stroke="${color}">
<div></div>
</svg>
`; // there used to be an error in minifier when string ends on new line
        }

        function Bars(color = "black") {
            return `<svg viewBox="0 0 57 57" xmlns="http://www.w3.org/2000/svg" stroke="${color}">
<div></div>
</svg>
`;
        }