namespace Calysto
{
	export enum NotifyHPosition
	{
		center = "center",
		right = "right",
		left = "left"
	}

	export enum NotifyVPosition
	{
		bottom = "bottom",
		top = "top"
	}

	let _zIndex = 2000000;

	export class Notification
	{
		public constructor(text: string)
		{
			this.Text = text;
		}

		public Text: string;

		public VPosition: keyof typeof NotifyVPosition = "top";

		public HPosition: keyof typeof NotifyHPosition = "center";

		public Icon: keyof typeof DialogIcon = "info";

		public PrefferedWidth: number = 500;

		public AutoCloseMs: number = 3000;

		public Set(fn: (notif: Notification) => void)
		{
			fn(this);
			return this;
		}

		private _containerEl: HTMLDivElement;
		private _notifBoxEl: HTMLDivElement;
		private _notifIconEl: HTMLSpanElement;
		private _notifContentEl: HTMLDivElement;
		private _notifInnerEl: HTMLDivElement;
		private _notifTextEl: HTMLTableCellElement;
		private _notifCloseBtnEl: HTMLSpanElement;

		private EnsureContainer()
		{
			let selector = ".calystoNotifyContainer." + this.VPosition + "." + this.HPosition;

			this._containerEl = <HTMLDivElement>$$calysto(selector).FirstOrDefault();
			if (this._containerEl)
				return;

			// create container
			let class1 = selector.ReplaceAll(".", " ").Trim();
			this._containerEl = <HTMLDivElement>Calysto.DomQuery.CreateElement("div").AddClass(class1).AddAsChildrenTo(document.body).FirstOrDefault();
			this._containerEl.style.zIndex = _zIndex + "";
		}

		private _template =
`<div class= 'calystoNotify2 hiddeNotifBox' >
	<div class='calystoNotifyInner'>
		<div class='calystoNotifyContent'>
			<table cellpadding='0' cellspacing='0'>
				<tr>
					<td class='tdIcon'><span class='calystoNotifyIcon'></span></td>
					<td class='calystoTextContent' style='width:100%'></td>
					<td class='tdBtnClose'><span class='calystoCloseBtn fa fa-times'></span></td>
				</tr>
			</table>
		</div>
	</div>
</div>`;


		private EnsureNotif()
		{
			if (!this._notifBoxEl)
			{
				let $$ = Calysto.DomQuery.FromHtml(this._template);
				this._notifBoxEl = <HTMLDivElement>$$.FirstOrDefault();

				this._notifInnerEl = <HTMLDivElement>$$.Query("//.calystoNotifyInner").FirstOrDefault();
				this._notifContentEl = <HTMLDivElement>$$.Query("//.calystoNotifyContent").AddClass(this.Icon).FirstOrDefault();
				this._notifTextEl = <HTMLTableCellElement>$$.Query("//.calystoTextContent").FirstOrDefault();

				let iconCls = "fa " + Calysto.GetFAIconClass(this.Icon);
				this._notifIconEl = <HTMLSpanElement>$$.Query("//.calystoNotifyIcon").SetVisible(this.Icon != "none").AddClass(iconCls).FirstOrDefault();

				this._notifCloseBtnEl = <HTMLSpanElement>$$.Query("//.calystoCloseBtn").FirstOrDefault();
				this._notifCloseBtnEl.onclick = () => this.Hide();
			}
		}

		public Show()
		{
			setTimeout(() =>
			{
				this.EnsureContainer();
				this.EnsureNotif();

				this._containerEl.style.maxWidth = this.PrefferedWidth + "px";

				this._notifTextEl.innerHTML = this.Text;

				if (this.VPosition == "top")
					$$calysto(this._containerEl).InsertChildren(this._notifBoxEl);
				else if (this.VPosition == "bottom")
					$$calysto(this._containerEl).AddChildren(this._notifBoxEl);

				this._notifBoxEl.style.height = "1px"; // da moze mjeriti dimenzije
				$$calysto(this._notifBoxEl).RemoveClass("hiddeNotifBox");
				this._notifBoxEl.style.height = this._notifInnerEl.offsetHeight + "px";

				if (this.AutoCloseMs > 0)
					setTimeout(() => this.Hide(), this.AutoCloseMs);

			}, 1);

			return this;
		}

		public Hide()
		{
			setTimeout(() =>
			{
				$$calysto(this._notifBoxEl).AddClass("hiddeNotifBox").Sleep(1500, sender => sender.RemoveFromDom());
			}, 1);
		}

		//*******************************************************************
		// static methods
		//*******************************************************************

		public static Create(
			text: string,
			icon: keyof typeof DialogIcon = "info",
			autoCloseMs: number = 3000,
			vPosition: keyof typeof NotifyVPosition = "top",
			hPosition: keyof typeof NotifyHPosition = "center"
		)
		{
			return new Calysto.Notification(text)
				.Set(n => n.Icon = icon)
				.Set(n => n.AutoCloseMs = autoCloseMs)
				.Set(n => n.VPosition = vPosition)
				.Set(n => n.HPosition = hPosition);
		}
	}
}

//let _cnt = 0;

//export function Notify(vPosition: NotifyVPosition, hPosition: NotifyHPosition)
//{
//	let nn = new Notification("ovo je sadrzajovo  " + (_cnt++));
//	nn.VPosition = vPosition;
//	nn.HPosition = hPosition;
//	nn.Icon = <Calysto.DialogIcon>["error", "success", "warning", "info"][Math.round(Math.random() * 3)];
//	nn.Show().AutoHide(4000);
//}

