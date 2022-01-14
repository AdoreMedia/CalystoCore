namespace Calysto.Preloaders
{
	export function Squares(color = "#98c7ef", backColor = "#4b84b5", rotateCCV = false)
	{
		let beginArr = [0, 0.125, 0.25, 0.375, 0.5, 0.625, 0.75, 0.875];
		let en1 = rotateCCV
			? beginArr.reverse().AsEnumerable().GetEnumerator()
			: beginArr.AsEnumerable().GetEnumerator();
		
		return `	<svg class="lds-blocks" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid">
		<rect x="17" y="17" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="40" y="17" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="63" y="17" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="63" y="40" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="63" y="63" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="40" y="63" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="17" y="63" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
		<rect x="17" y="40" width="20" height="20" fill="${backColor}">
			<animate attributeName="fill" values="${color};${backColor};${backColor}" keyTimes="0;0.125;1" dur="1s" repeatCount="indefinite" begin="${en1.GetNext().GetValue()}s" calcMode="discrete"></animate>
		</rect>
	</svg>`;

	}

	export function Snake(color = "black", rotateCCV = false)
	{
		let values = "0 0 0; 45 0 0; 90 0 0; 135 0 0; 180 0 0; 225 0 0 ; 270 0 0; 315 0 0; 360 0 0";
		let rArr = [5.375, 6.438, 8.063, 10.063, 10.75, 12.531, 14.344, 16];
		let en1 = rArr.AsEnumerable().GetEnumerator();

		if (rotateCCV)
		{
			values = values.split(";").reverse().join(";");
			en1 = rArr.reverse().AsEnumerable().GetEnumerator();
		}

		return `<svg class="snake-main" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" x="384" y="0">
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(45 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(90 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(135 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(180 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(225 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(270 64 64)" />
				<circle cx="16" cy="64" r="${en1.GetNext().GetValue()}" fill="${color}" transform="rotate(315 64 64)" />
				<animateTransform attributeName="transform" type="rotate" calcMode="discrete" values="${values}" keyTimes="0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
			</svg>`;
	}

	export function BallsRing(color = "black", rotateCCV = false)
	{
		let values = "0 0 0; 45 0 0; 90 0 0; 135 0 0; 180 0 0; 225 0 0 ; 270 0 0; 315 0 0; 360 0 0";
		let aArr = [0.1, 0.2, 0.35, 0.5, 0.7, 0.8, 0.9];
		let en1 = aArr.AsEnumerable().GetEnumerator();

		if (rotateCCV)
		{
			values = values.split(";").reverse().join(";");
			en1 = aArr.reverse().AsEnumerable().GetEnumerator();
		}

		let main1 = Colorspace.ColorConverter.ParseToRGB(color);
		return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" x="448" y="0">
			<circle cx="16" cy="64" r="16" fill="${main1.ToRgbString()}" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(45, 64, 64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(90,64,64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(135,64,64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(180,64,64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(225,64,64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(270,64,64)" />
			<circle cx="16" cy="64" r="16" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(315,64,64)" />
			<animateTransform attributeName="transform" type="rotate" calcMode="discrete" values="${values}" keyTimes="0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
		</svg>`;
	}

	export function MsRing(color = "black", backColor = "gainsboro", rotateCCV = false)
	{
		let values = "0 64 64; 45 64 64; 90 64 64; 135 64 64; 180 64 64; 225 64 64; 270 64 64; 315 64 64; 360 64 64";
		if (rotateCCV)
			values = values.split(";").reverse().join(";");

		return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" x="576" y="0">
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(45 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(90 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(135 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(180 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(225 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(270 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${backColor}" transform="rotate(315 64 64)" />
			<path d="M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z" fill="${color}">
				<animateTransform attributeName="transform" type="rotate" calcMode="discrete" values="${values}" keyTimes="0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
			</path>
		</svg>`;
	}

	export function TwoArrows(color = "black")
	{
		return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="10 10 108 108" x="704" y="0">
			<path fill="${color}" d="M109.25 55.5h-36l12-12a29.54 29.54 0 0 0-49.53 12H18.75A46.04 46.04 0 0 1 96.9 31.84l12.35-12.34v36zm-90.5 17h36l-12 12a29.54 29.54 0 0 0 49.53-12h16.97A46.04 46.04 0 0 1 31.1 96.16L18.74 108.5v-36z">
			</path>
			<animateTransform attributeName="transform" type="rotate" calcMode="linear" values="0 0 0;360 0 0" keyTimes="0;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
		</svg>`;
	}

	export function Flower(color = "black", rotateCCV = false)
	{
		let main1 = Colorspace.ColorConverter.ParseToRGB(color);
		let aArr = [0.1, 0.1, 0.1, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9];
		let en1 = aArr.AsEnumerable().GetEnumerator();
		let values = "0 0 0;30 0 0;60 0 0;90 0 0;120 0 0;150 0 0;180 0 0;210 0 0;240 0 0;270 0 0;300 0 0;330 0 0;360 0 0";

		if (rotateCCV)
		{
			values = values.split(";").reverse().join(";");
			en1 = aArr.reverse().AsEnumerable().GetEnumerator();
		}

		return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 128" x="640" y="0">
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.ToRgbString()}" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(30 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(60 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(90 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(120 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(150 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(180 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(210 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(240 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(270 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(300 64 64)" />
			<path d="M59.6 0h8v40h-8V0z" fill="${main1.Set(o => o.a = en1.GetNext().GetValue()).ToRgbString()}" transform="rotate(330 64 64)" />
			<animateTransform attributeName="transform" type="rotate" calcMode="discrete" values="${values}" keyTimes="0;0.08;0.16;0.25;0.33;0.42;0.5;0.58;0.67;0.75;0.83;0.92;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
		</svg>`;
	}

	export function ThreeArcs(color = "black", rotateCCV = false)
	{
		return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid" class="lds-dual-ring">
			<circle cx="50" cy="50" fill="none" stroke-linecap="round" r="40" stroke-width="15" stroke="${color}" stroke-dasharray="42.411500823462205 42.411500823462205" transform="rotate(60 50 50)">
				<animateTransform attributeName="transform" type="rotate" calcMode="linear" values="${rotateCCV ? 360 : 0} 50 50;${rotateCCV ? 0 : 360} 50 50" keyTimes="0;1" dur="1s" begin="0s" repeatCount="indefinite"></animateTransform>
			</circle>
		</svg>`;
	}

	export function ThreeDots(color = "black")
	{
		return `<svg viewBox="0 -45 120 120" xmlns="http://www.w3.org/2000/svg" fill="${color}">
    <circle cx="15" cy="15" r="15">
        <animate attributeName="r" from="15" to="15"
                 begin="0s" dur="0.8s"
                 values="15;9;15" calcMode="linear"
                 repeatCount="indefinite" />
        <animate attributeName="fill-opacity" from="1" to="1"
                 begin="0s" dur="0.8s"
                 values="1;.5;1" calcMode="linear"
                 repeatCount="indefinite" />
    </circle>
    <circle cx="60" cy="15" r="9" fill-opacity="0.3">
        <animate attributeName="r" from="9" to="9"
                 begin="0s" dur="0.8s"
                 values="9;15;9" calcMode="linear"
                 repeatCount="indefinite" />
        <animate attributeName="fill-opacity" from="0.5" to="0.5"
                 begin="0s" dur="0.8s"
                 values=".5;1;.5" calcMode="linear"
                 repeatCount="indefinite" />
    </circle>
    <circle cx="105" cy="15" r="15">
        <animate attributeName="r" from="15" to="15"
                 begin="0s" dur="0.8s"
                 values="15;9;15" calcMode="linear"
                 repeatCount="indefinite" />
        <animate attributeName="fill-opacity" from="1" to="1"
                 begin="0s" dur="0.8s"
                 values="1;.5;1" calcMode="linear"
                 repeatCount="indefinite" />
    </circle>
</svg>
`	}

	export function BallTriangle(color = "black")
	{
		return `<svg viewBox="0 0 57 57" xmlns="http://www.w3.org/2000/svg" stroke="${color}">
    <g fill="none" fill-rule="evenodd">
        <g transform="translate(1 1)" stroke-width="2">
            <circle cx="5" cy="50" r="5">
                <animate attributeName="cy"
                     begin="0s" dur="2.2s"
                     values="50;5;50;50"
                     calcMode="linear"
                     repeatCount="indefinite" />
                <animate attributeName="cx"
                     begin="0s" dur="2.2s"
                     values="5;27;49;5"
                     calcMode="linear"
                     repeatCount="indefinite" />
            </circle>
            <circle cx="27" cy="5" r="5">
                <animate attributeName="cy"
                     begin="0s" dur="2.2s"
                     from="5" to="5"
                     values="5;50;50;5"
                     calcMode="linear"
                     repeatCount="indefinite" />
                <animate attributeName="cx"
                     begin="0s" dur="2.2s"
                     from="27" to="27"
                     values="27;49;5;27"
                     calcMode="linear"
                     repeatCount="indefinite" />
            </circle>
            <circle cx="49" cy="50" r="5">
                <animate attributeName="cy"
                     begin="0s" dur="2.2s"
                     values="50;50;5;50"
                     calcMode="linear"
                     repeatCount="indefinite" />
                <animate attributeName="cx"
                     from="49" to="49"
                     begin="0s" dur="2.2s"
                     values="49;5;27;49"
                     calcMode="linear"
                     repeatCount="indefinite" />
            </circle>
        </g>
    </g>
</svg>`
	}

	export function Bars(color = "black")
	{
		return `<svg viewBox="0 0 135 140" xmlns="http://www.w3.org/2000/svg" fill="${color}">
    <rect y="10" width="15" height="120" rx="6">
        <animate attributeName="height"
             begin="0.5s" dur="1s"
             values="120;110;100;90;80;70;60;50;40;140;120" calcMode="linear"
             repeatCount="indefinite" />
        <animate attributeName="y"
             begin="0.5s" dur="1s"
             values="10;15;20;25;30;35;40;45;50;0;10" calcMode="linear"
             repeatCount="indefinite" />
    </rect>
    <rect x="30" y="10" width="15" height="120" rx="6">
        <animate attributeName="height"
             begin="0.25s" dur="1s"
             values="120;110;100;90;80;70;60;50;40;140;120" calcMode="linear"
             repeatCount="indefinite" />
        <animate attributeName="y"
             begin="0.25s" dur="1s"
             values="10;15;20;25;30;35;40;45;50;0;10" calcMode="linear"
             repeatCount="indefinite" />
    </rect>
    <rect x="60" width="15" height="140" rx="6">
        <animate attributeName="height"
             begin="0s" dur="1s"
             values="120;110;100;90;80;70;60;50;40;140;120" calcMode="linear"
             repeatCount="indefinite" />
        <animate attributeName="y"
             begin="0s" dur="1s"
             values="10;15;20;25;30;35;40;45;50;0;10" calcMode="linear"
             repeatCount="indefinite" />
    </rect>
    <rect x="90" y="10" width="15" height="120" rx="6">
        <animate attributeName="height"
             begin="0.25s" dur="1s"
             values="120;110;100;90;80;70;60;50;40;140;120" calcMode="linear"
             repeatCount="indefinite" />
        <animate attributeName="y"
             begin="0.25s" dur="1s"
             values="10;15;20;25;30;35;40;45;50;0;10" calcMode="linear"
             repeatCount="indefinite" />
    </rect>
    <rect x="120" y="10" width="15" height="120" rx="6">
        <animate attributeName="height"
             begin="0.5s" dur="1s"
             values="120;110;100;90;80;70;60;50;40;140;120" calcMode="linear"
             repeatCount="indefinite" />
        <animate attributeName="y"
             begin="0.5s" dur="1s"
             values="10;15;20;25;30;35;40;45;50;0;10" calcMode="linear"
             repeatCount="indefinite" />
    </rect>
</svg>
`}

	export function Oval(color = "black", backColor = "gainsboro", rotateCCV = false)
	{
		let strokeWidth = 4;
		let pathStart = 34;
		let radius = 18 - strokeWidth / 2;

		switch (strokeWidth)
		{
			case 2: pathStart = 36; break;
			case 4: pathStart = 34; break;
			case 8: pathStart = 32; break;
		}

		return `<svg viewBox="0 0 38 38" xmlns="http://www.w3.org/2000/svg" stroke="${color}">
    <g fill="none" fill-rule="evenodd">
        <g transform="translate(1 1)" stroke-width="2">
            <circle stroke-width="${strokeWidth}" stroke="${backColor}" stroke-opacity="1" cx="18" cy="18" r="${radius}"/>
            <path stroke-width="${strokeWidth}" d="M${pathStart} 18c0-9.94-8.06-${radius}-${radius}-${radius}">
                <animateTransform
                    attributeName="transform"
                    type="rotate"
                    from="${rotateCCV ? 360 : 0} 18 18"
                    to="${rotateCCV ? 0 : 360} 18 18"
                    dur="1s"
                    repeatCount="indefinite"/>
            </path>
        </g>
    </g>
</svg>`
	}

	export function Messenger(color?)
	{
		return `<svg class="lds-message" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid"><g transform="translate(20 50)">
<circle cx="0" cy="0" r="7" fill="${color || "#e15b64"}" transform="scale(0.99275 0.99275)">
  <animateTransform attributeName="transform" type="scale" begin="-0.375s" calcMode="spline" keySplines="0.3 0 0.7 1;0.3 0 0.7 1" values="0;1;0" keyTimes="0;0.5;1" dur="1s" repeatCount="indefinite"></animateTransform>
</circle>
</g><g transform="translate(40 50)">
<circle cx="0" cy="0" r="7" fill="${color || "#f47e60"}" transform="scale(0.773605 0.773605)">
  <animateTransform attributeName="transform" type="scale" begin="-0.25s" calcMode="spline" keySplines="0.3 0 0.7 1;0.3 0 0.7 1" values="0;1;0" keyTimes="0;0.5;1" dur="1s" repeatCount="indefinite"></animateTransform>
</circle>
</g><g transform="translate(60 50)">
<circle cx="0" cy="0" r="7" fill="${color || "#f8b26a"}" transform="scale(0.42525 0.42525)">
  <animateTransform attributeName="transform" type="scale" begin="-0.125s" calcMode="spline" keySplines="0.3 0 0.7 1;0.3 0 0.7 1" values="0;1;0" keyTimes="0;0.5;1" dur="1s" repeatCount="indefinite"></animateTransform>
</circle>
</g><g transform="translate(80 50)">
<circle cx="0" cy="0" r="7" fill="${color || "#abbd81"}" transform="scale(0.113418 0.113418)">
  <animateTransform attributeName="transform" type="scale" begin="0s" calcMode="spline" keySplines="0.3 0 0.7 1;0.3 0 0.7 1" values="0;1;0" keyTimes="0;0.5;1" dur="1s" repeatCount="indefinite"></animateTransform>
</circle>
</g></svg>`
	}

	export function RotatingBalls(color?)
	{
		return `<svg class="lds-microsoft" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid"><g transform="rotate(0)"><circle cx="81.73413361164941" cy="74.35045716034882" fill="${(color || "#e15b64")}" r="5" transform="rotate(340.001 49.9999 50)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="0s"></animateTransform>
</circle><circle cx="74.35045716034882" cy="81.73413361164941" fill="${(color || "#f47e60")}" r="5" transform="rotate(348.352 50.0001 50.0001)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.0625s"></animateTransform>
</circle><circle cx="65.3073372946036" cy="86.95518130045147" fill="${(color || "#f8b26a")}" r="5" transform="rotate(354.236 50 50)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.125s"></animateTransform>
</circle><circle cx="55.22104768880207" cy="89.65779445495241" fill="${(color || "#abbd81")}" r="5" transform="rotate(357.958 50.0002 50.0002)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.1875s"></animateTransform>
</circle><circle cx="44.77895231119793" cy="89.65779445495241" fill="${(color || "#849b87")}" r="5" transform="rotate(359.76 50.0064 50.0064)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.25s"></animateTransform>
</circle><circle cx="34.692662705396415" cy="86.95518130045147" fill="${(color || "#e15b64")}" r="5" transform="rotate(0.183552 50 50)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.3125s"></animateTransform>
</circle><circle cx="25.649542839651176" cy="81.73413361164941" fill="${(color || "#f47e60")}" r="5" transform="rotate(1.86457 50 50)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.375s"></animateTransform>
</circle><circle cx="18.2658663883506" cy="74.35045716034884" fill="${(color || "#f8b26a")}" r="5" transform="rotate(5.45126 50 50)">
  <animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;360 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s" begin="-0.4375s"></animateTransform>
</circle><animateTransform attributeName="transform" type="rotate" calcMode="spline" values="0 50 50;0 50 50" times="0;1" keySplines="0.5 0 0.5 1" repeatCount="indefinite" dur="1.5s"></animateTransform></g></svg>`
	}

 
}