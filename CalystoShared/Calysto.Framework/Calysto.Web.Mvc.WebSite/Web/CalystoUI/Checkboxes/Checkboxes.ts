namespace Calysto.Web.TestSite.Web.CalystoUI.Checkboxes.CheckboxesController
{
	// mark js file as EmbeddedResource for ScriptManager to load it in Release build
	// include js file using ScriptManager for Relese build
	// include js file on page with script tag for debugging

	// add your code here

	Calysto.Page.OnInteractive(() =>
	{
		let txt1 = CalystoEnumerable.From<CSSStyleSheet>(<any>document.styleSheets)
			.SelectMany(o => CalystoEnumerable.From<CSSStyleRule>(<any>o.cssRules))
			.Where(o => o.selectorText == ".calystoColorsList")
			.First().cssText;

		let kvColors = new Regex("([^ ]+)[\\s]*:[\\s]*([^ ]+); ")
			.Matches(txt1)
			.AsEnumerable()
			.Select(m => ({
				Name: m.Groups[1].replace("--calystoColor-", ""),
				Color: m.Groups[2]
			})).ToArray();

		// create all elements in all colors and themes

		kvColors.unshift({
			Name: "Default",
			Color: ""
		});

		console.log(txt1);
		console.log(kvColors);

		let themes1 = ["defaultTheme"];

		let $container = $$calysto("#divControlsContainer").ToList().AsDomQuery();

		for (let theme of themes1)
		{
			let div1 = Calysto.DomQuery.CreateElement("div").AddClass(theme).First();
			$container.AddChildren(div1);
			let $div1 = $$calysto(div1);

			$div1.AddChildren("<h2>" + theme + " with calystoBtn</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateButton(kv.Name + " calystoBtn")).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " no calystoBtn</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateButton(kv.Name)).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme +  " with calystoBtn</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateSelects(kv.Name + " calystoBtn")).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " no calystoBtn</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateSelects(kv.Name)).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " with calystoInp</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateInput(kv.Name + " calystoInp")).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " no calystoInp</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateInput(kv.Name)).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " with calystoInp</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateTextArea(kv.Name + " calystoInp")).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren("<h2>" + theme + " no calystoInp</h2>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateTextArea(kv.Name)).ToArray());
			$div1.AddChildren("<hr/>");
		}

		for (let theme of themes1)
		{
			let div1 = Calysto.DomQuery.CreateElement("div").AddClass(theme).First();
			$container.AddChildren(div1);
			let $div1 = $$calysto(div1);
			$div1.AddChildren("<h2>" + theme + "</h2>");

			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name, "checkbox")).ToArray());
			$div1.AddChildren("<hr/>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name, "checkbox", true)).ToArray());
			$div1.AddChildren("<hr/>");

			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name + " right", "checkbox")).ToArray());
			$div1.AddChildren("<hr/>");
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name + " right", "checkbox", true)).ToArray());
			$div1.AddChildren("<hr/>");

			let name1 = Calysto.Utility.Generators.GenerateLabel(10);
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name, "radio", false, name1)).ToArray());
			$div1.AddChildren("<hr/>");
			name1 = Calysto.Utility.Generators.GenerateLabel(10);
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name, "radio", true, name1)).ToArray());
			$div1.AddChildren("<hr/>");

			name1 = Calysto.Utility.Generators.GenerateLabel(10);
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name + " right", "radio", false, name1)).ToArray());
			$div1.AddChildren("<hr/>");
			name1 = Calysto.Utility.Generators.GenerateLabel(10);
			$div1.AddChildren(kvColors.AsEnumerable().Select(kv => fnCreateCheckbox(kv.Name + " right", "radio", true, name1)).ToArray());
			$div1.AddChildren("<hr/>");
		}

		// set disabled buttons
		// calystoChk is on label, we have to set disabled on child input element to disable changing it's checked state on click
		$$calysto(".calystoOrange").Query("*, //input").SetEnabled(false);
	});

	function fnCreateCheckbox(cls, type, isChecked = false, groupName?)
	{

		return `<label class="${cls} calystoChk" style="display:inline-block;margin:0 5px 5px 0;background:gainsboro;min-width:270px;">
			<input type="${type}" name="${groupName}" ${(isChecked ? "checked" : "")} ${(cls.Contains("ccolorGreen") ? "disabled" : "")} />
			<span>${cls}</span>
		</label>`;
	}

	function fnCreateButton(cls)
	{
		return `<button type="submit" value="${cls}" class="${cls}" style="margin:0 5px 5px 0" >
			<div align="center" style="white-space:nowrap;">
				<table cellpadding="0" cellspacing="0" style="width:100%">
					<tr>
						<td style="width:26px;position:relative;">
							<img src="~/WebLib/Images/Icons/s16/silk/icons/accept.png" />
						</td>
						<td class="calystoLabelText">${cls}</td>
					</tr>
				</table>
			</div>
		</button>`
	}

	function fnCreateSelects(cls)
	{
		return `<select name="ctl15" class="${cls}" style="margin:0 5px 5px 0">
			<option value="prvi">prvi</option>
			<option value="drugi">drugi</option>
			<option value="treci">treci</option>
		</select>`;
	}

	function fnCreateInput(cls)
	{
		return `<input class="${cls}" type="text" value="${cls}" style="margin:0 5px 5px 0" />`;
	}

	function fnCreateTextArea(cls)
	{
		return `<textarea class="${cls}" style="margin:0 5px 5px 0" >${cls}</textarea>`;
	}

}
