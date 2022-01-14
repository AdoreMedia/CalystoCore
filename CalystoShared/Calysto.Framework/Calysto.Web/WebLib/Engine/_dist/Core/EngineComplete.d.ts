/// <reference path="../../src/core/d.ts/IRuntimeConstants.d.ts" />
/// <reference path="../../../Extern/facebook-js-sdk.d.ts" />
/// <reference path="../../../Extern/gapi-index.d.ts" />
/// <reference path="../../../Extern/gapi.auth-index.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.form.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.validate.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.validate.unobtrusive.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.soap.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.cycle.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.color.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.pajax.d.ts" />
/// <reference path="../../../Extern/bootstrap/bootstrap.d.ts" />
/// <reference path="../../src/core/d.ts/CalystoInterfaces.d.ts" />
/// <reference path="../../src/core/d.ts/CalystoDeclarations.d.ts" />
/// <reference path="../../Src/Core/Extension/Date.d.ts" />
/// <reference path="../../Src/Core/Extension/Location.d.ts" />
/// <reference path="../../Src/Core/Extension/Array.d.ts" />
/// <reference path="../../src/core/Binding/Binding.d.ts" />
declare namespace Calysto.Tasks {
    /**
     *  Promise implementation for IE <= 11 where Promise is not implemented
     *  Complete implementation compatible with window.Promise
     */
    class CPromise {
        private executor?;
        constructor(executor?: ((resolve: (value?: any) => void, reject: (value?: any) => void) => void) | undefined);
        private _isResolved;
        private _resolveValue;
        private _isRejected;
        private _rejectValue;
        protected notifyResolved(value?: any): void;
        protected notifyRejected(value?: any): void;
        private _nextPromise;
        private _isNextNotified;
        private notifyNext;
        private _onPreviousSuccess;
        private _onPreviousFailed;
        then(onResolved?: (value?: any) => any, onRejected?: (value?: any) => any): CPromise;
        catch(fn?: (value?: any) => any): CPromise;
        finally(fn?: () => any): CPromise;
        static resolve(value?: any): CPromise;
        static reject(value?: any): CPromise;
    }
}
declare namespace Calysto.Tasks.TaskUtility {
    function SleepAsync(durationMs: number, cancellationToken?: CancellationToken): Promise<void>;
    /**
     *
     * @param executor must have async to return promise.
     * @param cancellationToken
     */
    function RunAsync<TResult>(executor: () => Promise<TResult>, cancellationToken?: CancellationToken): Promise<TResult>;
    /**
     * To return from await, resolveCallback(result) has to be invoked inside executor method.
     * @param executor executor: (resolveCallback(result)=>void)=>void
     */
    function CallbackAsync<TResult>(executor: (resolveCallback: (result: TResult) => void) => void, cancellationToken?: CancellationToken): Promise<TResult>;
    function TimeoutAsync<TResult>(promise1: Promise<TResult>, timeoutMs: number): Promise<any>;
}
interface Promise<T> {
    TimeoutAsync(timeoutMs: number): Promise<T>;
}
declare namespace Calysto.Tasks.TaskUtility {
}
declare namespace Calysto.Tasks {
    /**
     * Execute async tasks one by one or in parallel if paralelisim > 1
     */
    class ParallelScheduler<TResult> {
        private _queue;
        private _runningCount;
        private _paralelism;
        constructor(paralelisim: number);
        private _logListeners;
        OnLog(fn: (string: any) => void): void;
        private NotifyLog;
        private StartNextAction;
        private StartPool;
        /**
         * Add new executor method. Added methods will be executed one by one or in parallel if paralelisim > 0.
         * @param executor
         */
        RunScheduledAsync(executor: (resolve: (TResult: any) => void) => void): Promise<TResult>;
    }
}
declare namespace Calysto.Tasks {
    export class TaskCompletionSource<TResult> {
        private _hasResult;
        private _hasError;
        private _promise;
        private _fnResolve;
        private _result;
        private _fnReject;
        private _error;
        constructor();
        TrySetResult(result: TResult): boolean;
        TrySetException(reason: any): boolean;
        TrySetCanceled(): boolean;
        get Task(): Promise<TResult>;
    }
    class CancellationTokenRegistration {
        private fnUnregister;
        constructor(fnUnregister: () => void);
        /** Remove callback registered using CancellationToken.Register() */
        Unregister(): void;
    }
    export abstract class CancellationToken {
        constructor();
        protected _isCancellationRequested: boolean;
        get IsCancellationRequested(): boolean;
        protected _onCancelled: (() => void)[];
        /**
         * Register callback to be invoked when token is cancelled.
         * @param onCancelled
         */
        Register(onCancelled: () => void): CancellationTokenRegistration;
    }
    export class CancellationTokenSource extends CancellationToken implements IDisposable {
        private _timeoutId;
        constructor(millisecondsDelay?: number);
        private _isDisposed;
        get IsDisposed(): boolean;
        Dispose(): void;
        get Token(): CancellationToken;
        private NotifyCanceled;
        Cancel(): void;
        /**
         * Abort and than start new cancelation timer.
         * @param millisecondsDelay
         * if > 0, will re-start cancelation timer.
         * if <= 0, will abort previous timer and will not start the new one.
         */
        CancelAfter(millisecondsDelay?: number): void;
        /**
         * Creates a CancellationTokenSource that will be in the canceled state when any of the source tokens are in the canceled state.
         * @param tokens
         */
        static CreateLinkedTokenSource(token1?: CancellationToken, token2?: CancellationToken, token3?: CancellationToken, token4?: CancellationToken): CancellationTokenSource;
    }
    export {};
}
declare namespace Calysto.Tasks {
    class CalystoMonitor<TResult> {
        private _items;
        constructor();
        WaitAsync(timeoutMs?: number, cancellationToken?: CancellationToken): Promise<TResult>;
        /**
         * Pulse first unpulsed and unresolved promise.
         * @param value
         */
        Pulse(value?: TResult): void;
        /**
         * Pulse all unpulsed and unresolved promises.
         * @param value
         */
        PulseAll(value?: TResult): void;
    }
}
declare namespace Calysto.Resources.Images {
    const Arrows_ArrowBlackDown = "~/Images/Arrows/ArrowBlackDown.png";
    const Arrows_ArrowBlackUp = "~/Images/Arrows/ArrowBlackUp.png";
    const Arrows_ArrowWhiteDown = "~/Images/Arrows/ArrowWhiteDown.png";
    const Arrows_ArrowWhiteUp = "~/Images/Arrows/ArrowWhiteUp.png";
    const Pictures_facebook_icon = "~/Images/Pictures/facebook-icon.png";
    const Pictures_Google_Plus_icon = "~/Images/Pictures/Google-Plus-icon.png";
    const Pictures_NoPhoto100 = "~/Images/Pictures/NoPhoto100.gif";
    const Pictures_NoPhoto200 = "~/Images/Pictures/NoPhoto200.gif";
    const Pictures_NoPhoto300 = "~/Images/Pictures/NoPhoto300.gif";
    const Pictures_NoPhoto50 = "~/Images/Pictures/NoPhoto50.gif";
    const WindowButtons_btnClose = "~/Images/WindowButtons/btnClose.gif";
    const WindowButtons_btnCloseHover = "~/Images/WindowButtons/btnCloseHover.gif";
    const WindowButtons_btnCloseInactive = "~/Images/WindowButtons/btnCloseInactive.gif";
    const WindowButtons_btnMaximized = "~/Images/WindowButtons/btnMaximized.gif";
    const WindowButtons_btnMaximizedHover = "~/Images/WindowButtons/btnMaximizedHover.gif";
    const WindowButtons_btnMaximizedInactive = "~/Images/WindowButtons/btnMaximizedInactive.gif";
    const WindowButtons_btnMinimize = "~/Images/WindowButtons/btnMinimize.gif";
    const WindowButtons_btnMinimizeHover = "~/Images/WindowButtons/btnMinimizeHover.gif";
    const WindowButtons_btnMinimizeInactive = "~/Images/WindowButtons/btnMinimizeInactive.gif";
    const WindowButtons_btnResize = "~/Images/WindowButtons/btnResize.gif";
    const WindowButtons_btnResizeHover = "~/Images/WindowButtons/btnResizeHover.gif";
    const WindowButtons_btnResizeInactive = "~/Images/WindowButtons/btnResizeInactive.gif";
    const WindowButtons_btnToolClose = "~/Images/WindowButtons/btnToolClose.gif";
    const WindowButtons_btnToolCloseHover = "~/Images/WindowButtons/btnToolCloseHover.gif";
    const Horoscope_Icons_aquarius_128 = "~/Images/Horoscope/Icons/aquarius_128.png";
    const Horoscope_Icons_aries_128 = "~/Images/Horoscope/Icons/aries_128.png";
    const Horoscope_Icons_cancer_128 = "~/Images/Horoscope/Icons/cancer_128.png";
    const Horoscope_Icons_capricorn_128 = "~/Images/Horoscope/Icons/capricorn_128.png";
    const Horoscope_Icons_gemini_128 = "~/Images/Horoscope/Icons/gemini_128.png";
    const Horoscope_Icons_leo_128 = "~/Images/Horoscope/Icons/leo_128.png";
    const Horoscope_Icons_libra_128 = "~/Images/Horoscope/Icons/libra_128.png";
    const Horoscope_Icons_pisces_128 = "~/Images/Horoscope/Icons/pisces_128.png";
    const Horoscope_Icons_sagittarius_128 = "~/Images/Horoscope/Icons/sagittarius_128.png";
    const Horoscope_Icons_scorpio_128 = "~/Images/Horoscope/Icons/scorpio_128.png";
    const Horoscope_Icons_taurus_128 = "~/Images/Horoscope/Icons/taurus_128.png";
    const Horoscope_Icons_virgo_128 = "~/Images/Horoscope/Icons/virgo_128.png";
    const Horoscope_Signs_aquarius_zodiac_sign = "~/Images/Horoscope/Signs/aquarius_zodiac_sign.png";
    const Horoscope_Signs_aries_zodiac_sign = "~/Images/Horoscope/Signs/aries_zodiac_sign.png";
    const Horoscope_Signs_cancer_zodiac_sign = "~/Images/Horoscope/Signs/cancer_zodiac_sign.png";
    const Horoscope_Signs_capricorn_zodiac_sign = "~/Images/Horoscope/Signs/capricorn_zodiac_sign.png";
    const Horoscope_Signs_gemini_zodiac_sign = "~/Images/Horoscope/Signs/gemini_zodiac_sign.png";
    const Horoscope_Signs_leo_zodiac_sign = "~/Images/Horoscope/Signs/leo_zodiac_sign.png";
    const Horoscope_Signs_libra_zodiac_sign = "~/Images/Horoscope/Signs/libra_zodiac_sign.png";
    const Horoscope_Signs_pisces_zodiac_sign = "~/Images/Horoscope/Signs/pisces_zodiac_sign.png";
    const Horoscope_Signs_sagittarius_zodiac_sign = "~/Images/Horoscope/Signs/sagittarius_zodiac_sign.png";
    const Horoscope_Signs_scorpio_zodiac_sign = "~/Images/Horoscope/Signs/scorpio_zodiac_sign.png";
    const Horoscope_Signs_taurus_zodiac_sign = "~/Images/Horoscope/Signs/taurus_zodiac_sign.png";
    const Horoscope_Signs_virgo_zodiac_sign = "~/Images/Horoscope/Signs/virgo_zodiac_sign.png";
    const Icons_Ajax2Preloader_Ajax12TrailBlack = "~/Images/Icons/Ajax2Preloader/Ajax12TrailBlack.gif";
    const Icons_Ajax2Preloader_Ajax14FlowerBlack = "~/Images/Icons/Ajax2Preloader/Ajax14FlowerBlack.gif";
    const Icons_Ajax2Preloader_Ajax14TrailBlack = "~/Images/Icons/Ajax2Preloader/Ajax14TrailBlack.gif";
    const Icons_Ajax2Preloader_Ajax16ArcBlack = "~/Images/Icons/Ajax2Preloader/Ajax16ArcBlack.gif";
    const Icons_Ajax2Preloader_Ajax16ArrowsBlack = "~/Images/Icons/Ajax2Preloader/Ajax16ArrowsBlack.gif";
    const Icons_Ajax2Preloader_Ajax16DotBlack = "~/Images/Icons/Ajax2Preloader/Ajax16DotBlack.gif";
    const Icons_Ajax2Preloader_Ajax24DotBlack = "~/Images/Icons/Ajax2Preloader/Ajax24DotBlack.gif";
    const Icons_Ajax2Preloader_Ajax24DotBlue = "~/Images/Icons/Ajax2Preloader/Ajax24DotBlue.gif";
    const Icons_Ajax2Preloader_Ajax24DotRed = "~/Images/Icons/Ajax2Preloader/Ajax24DotRed.gif";
    const Icons_Ajax2Preloader_Ajax32SandClock = "~/Images/Icons/Ajax2Preloader/Ajax32SandClock.png";
    const Icons_Ajax2Preloader_FB_black_small = "~/Images/Icons/Ajax2Preloader/FB_black_small.gif";
    const Icons_Ajax2Preloader_skype_black2white = "~/Images/Icons/Ajax2Preloader/skype_black2white.GIF";
    const Icons_Ajax2Preloader_skype_blue2white = "~/Images/Icons/Ajax2Preloader/skype_blue2white.GIF";
    const Icons_Ajax2Preloader_skype_green2white = "~/Images/Icons/Ajax2Preloader/skype_green2white.GIF";
    const Icons_Ajax2Preloader_skype_red2white = "~/Images/Icons/Ajax2Preloader/skype_red2white.GIF";
    const Icons_Ajax2Preloader_skype_white2black = "~/Images/Icons/Ajax2Preloader/skype_white2black.GIF";
    const Icons_Smiley_angry = "~/Images/Icons/Smiley/angry.gif";
    const Icons_Smiley_applause = "~/Images/Icons/Smiley/applause.gif";
    const Icons_Smiley_bigGrin = "~/Images/Icons/Smiley/bigGrin.gif";
    const Icons_Smiley_bigHug = "~/Images/Icons/Smiley/bigHug.gif";
    const Icons_Smiley_confused = "~/Images/Icons/Smiley/confused.gif";
    const Icons_Smiley_cool = "~/Images/Icons/Smiley/cool.gif";
    const Icons_Smiley_crying = "~/Images/Icons/Smiley/crying.gif";
    const Icons_Smiley_dancing = "~/Images/Icons/Smiley/dancing.gif";
    const Icons_Smiley_devil = "~/Images/Icons/Smiley/devil.gif";
    const Icons_Smiley_dontTellAnyone = "~/Images/Icons/Smiley/dontTellAnyone.gif";
    const Icons_Smiley_happy = "~/Images/Icons/Smiley/happy.gif";
    const Icons_Smiley_hurryUp = "~/Images/Icons/Smiley/hurryUp.gif";
    const Icons_Smiley_kiss = "~/Images/Icons/Smiley/kiss.gif";
    const Icons_Smiley_laughing = "~/Images/Icons/Smiley/laughing.gif";
    const Icons_Smiley_notWorthy = "~/Images/Icons/Smiley/notWorthy.gif";
    const Icons_Smiley_party = "~/Images/Icons/Smiley/party.gif";
    const Icons_Smiley_rockOn = "~/Images/Icons/Smiley/rockOn.gif";
    const Icons_Smiley_rollingOnTheFloor = "~/Images/Icons/Smiley/rollingOnTheFloor.gif";
    const Icons_Smiley_sad = "~/Images/Icons/Smiley/sad.gif";
    const Icons_Smiley_surprise = "~/Images/Icons/Smiley/surprise.gif";
    const Icons_Smiley_thinking = "~/Images/Icons/Smiley/thinking.gif";
    const Icons_Smiley_thumbsDown = "~/Images/Icons/Smiley/thumbsDown.gif";
    const Icons_Smiley_tongue = "~/Images/Icons/Smiley/tongue.gif";
    const Icons_Smiley_winking = "~/Images/Icons/Smiley/winking.gif";
    const WindowButtons_Original_PNG_btnClose = "~/Images/WindowButtons/Original_PNG/btnClose.png";
    const WindowButtons_Original_PNG_btnCloseHover = "~/Images/WindowButtons/Original_PNG/btnCloseHover.png";
    const WindowButtons_Original_PNG_btnCloseInactive = "~/Images/WindowButtons/Original_PNG/btnCloseInactive.png";
    const WindowButtons_Original_PNG_btnMaximized = "~/Images/WindowButtons/Original_PNG/btnMaximized.png";
    const WindowButtons_Original_PNG_btnMaximizedHover = "~/Images/WindowButtons/Original_PNG/btnMaximizedHover.png";
    const WindowButtons_Original_PNG_btnMaximizedInactive = "~/Images/WindowButtons/Original_PNG/btnMaximizedInactive.png";
    const WindowButtons_Original_PNG_btnMinimize = "~/Images/WindowButtons/Original_PNG/btnMinimize.png";
    const WindowButtons_Original_PNG_btnMinimizeHover = "~/Images/WindowButtons/Original_PNG/btnMinimizeHover.png";
    const WindowButtons_Original_PNG_btnMinimizeInactive = "~/Images/WindowButtons/Original_PNG/btnMinimizeInactive.png";
    const WindowButtons_Original_PNG_btnResize = "~/Images/WindowButtons/Original_PNG/btnResize.png";
    const WindowButtons_Original_PNG_btnResizeHover = "~/Images/WindowButtons/Original_PNG/btnResizeHover.png";
    const WindowButtons_Original_PNG_btnResizeInactive = "~/Images/WindowButtons/Original_PNG/btnResizeInactive.png";
    const WindowButtons_Original_PNG_btnToolClose = "~/Images/WindowButtons/Original_PNG/btnToolClose.png";
    const WindowButtons_Original_PNG_btnToolCloseHover = "~/Images/WindowButtons/Original_PNG/btnToolCloseHover.png";
    const Icons_s32_aha_Apply = "~/Images/Icons/s32/aha/Apply.png";
    const Icons_s32_aha_Back = "~/Images/Icons/s32/aha/Back.png";
    const Icons_s32_aha_Cancel = "~/Images/Icons/s32/aha/Cancel.png";
    const Icons_s32_aha_Close = "~/Images/Icons/s32/aha/Close.png";
    const Icons_s32_aha_Danger = "~/Images/Icons/s32/aha/Danger.png";
    const Icons_s32_aha_Delete = "~/Images/Icons/s32/aha/Delete.png";
    const Icons_s32_aha_EditPage = "~/Images/Icons/s32/aha/EditPage.png";
    const Icons_s32_aha_Error = "~/Images/Icons/s32/aha/Error.png";
    const Icons_s32_aha_Forward = "~/Images/Icons/s32/aha/Forward.png";
    const Icons_s32_aha_GoDown = "~/Images/Icons/s32/aha/GoDown.png";
    const Icons_s32_aha_GoUp = "~/Images/Icons/s32/aha/GoUp.png";
    const Icons_s32_aha_Help = "~/Images/Icons/s32/aha/Help.png";
    const Icons_s32_aha_Info = "~/Images/Icons/s32/aha/Info.png";
    const Icons_s32_aha_No = "~/Images/Icons/s32/aha/No.png";
    const Icons_s32_aha_Ok = "~/Images/Icons/s32/aha/Ok.png";
    const Icons_s32_aha_Pencil = "~/Images/Icons/s32/aha/Pencil.png";
    const Icons_s32_aha_Picture = "~/Images/Icons/s32/aha/Picture.png";
    const Icons_s32_aha_Play = "~/Images/Icons/s32/aha/Play.png";
    const Icons_s32_aha_Refresh = "~/Images/Icons/s32/aha/Refresh.png";
    const Icons_s32_aha_Settings = "~/Images/Icons/s32/aha/Settings.png";
    const Icons_s32_aha_Show = "~/Images/Icons/s32/aha/Show.png";
    const Icons_s32_aha_Stop = "~/Images/Icons/s32/aha/Stop.png";
    const Icons_s32_aha_StopPlaying = "~/Images/Icons/s32/aha/StopPlaying.png";
    const Icons_s32_aha_Warning = "~/Images/Icons/s32/aha/Warning.png";
    const Icons_s32_aha_Wrong = "~/Images/Icons/s32/aha/Wrong.png";
    const Icons_s32_fatcow_film = "~/Images/Icons/s32/fatcow/film.png";
    const Icons_s16_silk_icons_accept = "~/Images/Icons/s16/silk/icons/accept.png";
    const Icons_s16_silk_icons_add = "~/Images/Icons/s16/silk/icons/add.png";
    const Icons_s16_silk_icons_anchor = "~/Images/Icons/s16/silk/icons/anchor.png";
    const Icons_s16_silk_icons_application = "~/Images/Icons/s16/silk/icons/application.png";
    const Icons_s16_silk_icons_application_edit = "~/Images/Icons/s16/silk/icons/application_edit.png";
    const Icons_s16_silk_icons_brick_edit = "~/Images/Icons/s16/silk/icons/brick_edit.png";
    const Icons_s16_silk_icons_cancel = "~/Images/Icons/s16/silk/icons/cancel.png";
    const Icons_s16_silk_icons_cross = "~/Images/Icons/s16/silk/icons/cross.png";
    const Icons_s16_silk_icons_date = "~/Images/Icons/s16/silk/icons/date.png";
    const Icons_s16_silk_icons_delete = "~/Images/Icons/s16/silk/icons/delete.png";
    const Icons_s16_silk_icons_disconnect = "~/Images/Icons/s16/silk/icons/disconnect.png";
    const Icons_s16_silk_icons_disk = "~/Images/Icons/s16/silk/icons/disk.png";
    const Icons_s16_silk_icons_error = "~/Images/Icons/s16/silk/icons/error.png";
    const Icons_s16_silk_icons_exclamation = "~/Images/Icons/s16/silk/icons/exclamation.png";
    const Icons_s16_silk_icons_eye = "~/Images/Icons/s16/silk/icons/eye.png";
    const Icons_s16_silk_icons_feed = "~/Images/Icons/s16/silk/icons/feed.png";
    const Icons_s16_silk_icons_help = "~/Images/Icons/s16/silk/icons/help.png";
    const Icons_s16_silk_icons_hourglass = "~/Images/Icons/s16/silk/icons/hourglass.png";
    const Icons_s16_silk_icons_lock_break = "~/Images/Icons/s16/silk/icons/lock_break.png";
    const Icons_s16_silk_icons_magifier_zoom_out = "~/Images/Icons/s16/silk/icons/magifier_zoom_out.png";
    const Icons_s16_silk_icons_magnifier = "~/Images/Icons/s16/silk/icons/magnifier.png";
    const Icons_s16_silk_icons_magnifier_zoom_in = "~/Images/Icons/s16/silk/icons/magnifier_zoom_in.png";
    const Icons_s16_silk_icons_male = "~/Images/Icons/s16/silk/icons/male.png";
    const Icons_s16_silk_icons_map = "~/Images/Icons/s16/silk/icons/map.png";
    const Icons_s16_silk_icons_page_add = "~/Images/Icons/s16/silk/icons/page_add.png";
    const Icons_s16_silk_icons_page_edit = "~/Images/Icons/s16/silk/icons/page_edit.png";
    const Icons_s16_silk_icons_page_white = "~/Images/Icons/s16/silk/icons/page_white.png";
    const Icons_s16_silk_icons_picture = "~/Images/Icons/s16/silk/icons/picture.png";
    const Icons_s16_silk_icons_pictures = "~/Images/Icons/s16/silk/icons/pictures.png";
    const Icons_s16_silk_icons_picture_add = "~/Images/Icons/s16/silk/icons/picture_add.png";
    const Icons_s16_silk_icons_plugin = "~/Images/Icons/s16/silk/icons/plugin.png";
    const Icons_s16_silk_icons_plugin_edit = "~/Images/Icons/s16/silk/icons/plugin_edit.png";
    const Icons_s16_silk_icons_stop = "~/Images/Icons/s16/silk/icons/stop.png";
    const Icons_s16_silk_icons_thumb_down = "~/Images/Icons/s16/silk/icons/thumb_down.png";
    const Icons_s16_silk_icons_thumb_up = "~/Images/Icons/s16/silk/icons/thumb_up.png";
    const Icons_s16_silk_icons_tick = "~/Images/Icons/s16/silk/icons/tick.png";
    const Icons_s16_silk_icons_time = "~/Images/Icons/s16/silk/icons/time.png";
    const Icons_s16_silk_icons_user = "~/Images/Icons/s16/silk/icons/user.png";
    const Icons_s16_silk_icons_zoom = "~/Images/Icons/s16/silk/icons/zoom.png";
    const Icons_s16_silk_icons_zoom_in = "~/Images/Icons/s16/silk/icons/zoom_in.png";
    const Icons_s16_silk_icons_zoom_out = "~/Images/Icons/s16/silk/icons/zoom_out.png";
}
declare namespace Calysto.Constants.AppConstants {
    const EmailRegexPattern = "^[\\w\\.\\+\\-_']+[@][\\w\\+\\-_']+?[\\.][\\w\\.\\+\\-_']+$";
    const BroadcastMethodName = "$broadcast-message$";
    const EchoServerRequest = "EchoServerRequest";
    const EchoServerResponse = "EchoServerResponse";
    const EchoClientRequest = "EchoClientRequest";
    const EchoClientResponse = "EchoClientResponse";
}
declare namespace Calysto.Constants.WsjsHeaderConstants {
    const XAjaxHeaderKey = "x-calysto-ajax";
    const XAjaxHeaderValue = "calysto-ajax";
    const XExceptionHeaderValue = "calysto-exception";
    const XTypeHeaderKey = "x-calysto-type";
    const XTypeHeaderBinaryFrameValue = "calysto-binary-frame";
    const XCalystoAjaxFormKey = "x-calysto-ajax-form";
    const XCalystoAjaxFormValue = "calysto-form";
    const XCalystoAjaxLoadKey = "x-calysto-ajax-load";
    const XCalystoAjaxLoadValue = "calysto-load";
    const XCalystoResponseContainerKey = "x-calysto-container";
    const XCalystoResponseContainerValue = "calysto-container";
    const XCalystoFileNameKey = "x-calysto-filename";
    const XCalystoRequestWithKey = "x-calysto-request-with";
    const XCalystoRequestWithValue = "calysto-web-client";
    const XCalystoContentTypeKey = "x-calysto-content-type";
    const XCalystoPageStateKey = "x-calysto-page-state";
    const XCalystoPageStateValue = "XCalystoPageStateValue";
}
declare namespace Calysto.Constants {
    const PredefinedCultures: {
        "en-US": {
            Name: string;
            NativeName: string;
            DisplayName: string;
            EnglishName: string;
            ThreeLetterISOLanguageName: string;
            ThreeLetterWindowsLanguageName: string;
            TwoLetterISOLanguageName: string;
            DateTimeFormat: {
                ShortestDayNames: string[];
                AbbreviatedDayNames: string[];
                DayNames: string[];
                AbbreviatedMonthNames: string[];
                MonthNames: string[];
                FirstDayOfWeek: number;
                LongDatePattern: string;
                LongTimePattern: string;
                MonthDayPattern: string;
                ShortDatePattern: string;
                ShortTimePattern: string;
                GeneralLongTimePattern: string;
                GeneralShortTimePattern: string;
            };
            NumberFormat: {
                CurrencySymbol: string;
                NumberDecimalSeparator: string;
                NumberGroupSeparator: string;
                PerMilleSymbol: string;
                PercentSymbol: string;
                CurrencyPositivePattern: number;
                CurrencyPositivePatternString: string;
            };
            Region: {
                CurrencyEnglishName: string;
                CurrencyNativeName: string;
                CurrencySymbol: string;
                DisplayName: string;
                EnglishName: string;
                IsMetric: boolean;
                ISOCurrencySymbol: string;
                Name: string;
                NativeName: string;
                ThreeLetterISORegionName: string;
                ThreeLetterWindowsRegionName: string;
                TwoLetterISORegionName: string;
            };
        };
        "hr-HR": {
            Name: string;
            NativeName: string;
            DisplayName: string;
            EnglishName: string;
            ThreeLetterISOLanguageName: string;
            ThreeLetterWindowsLanguageName: string;
            TwoLetterISOLanguageName: string;
            DateTimeFormat: {
                ShortestDayNames: string[];
                AbbreviatedDayNames: string[];
                DayNames: string[];
                AbbreviatedMonthNames: string[];
                MonthNames: string[];
                FirstDayOfWeek: number;
                LongDatePattern: string;
                LongTimePattern: string;
                MonthDayPattern: string;
                ShortDatePattern: string;
                ShortTimePattern: string;
                GeneralLongTimePattern: string;
                GeneralShortTimePattern: string;
            };
            NumberFormat: {
                CurrencySymbol: string;
                NumberDecimalSeparator: string;
                NumberGroupSeparator: string;
                PerMilleSymbol: string;
                PercentSymbol: string;
                CurrencyPositivePattern: number;
                CurrencyPositivePatternString: string;
            };
            Region: {
                CurrencyEnglishName: string;
                CurrencyNativeName: string;
                CurrencySymbol: string;
                DisplayName: string;
                EnglishName: string;
                IsMetric: boolean;
                ISOCurrencySymbol: string;
                Name: string;
                NativeName: string;
                ThreeLetterISORegionName: string;
                ThreeLetterWindowsRegionName: string;
                TwoLetterISORegionName: string;
            };
        };
    };
}
declare namespace Calysto.Constants.CalystoDomAttributes {
    const CalystoId = "calysto-id";
    const CalystoValidatorMsgFor = "calysto-validator-msg-for";
    const CalystoSummaryMsgFor = "calysto-summary-msg-for";
    const CalystoErrorMsgFor = "calysto-error-msg-for";
    const CalystoType = "calysto-type";
    const CalystoGetter = "calysto-getter";
    const CalystoSetter = "calysto-setter";
    const CalystoFormat = "calysto-format";
    const CalystoValidationFn = "calysto-validation-fn";
    const CalystoBind = "calysto-bind";
    const CalystoBindEvents = "calysto-bind-events";
    const CalystoListen = "calysto-listen";
    const CalystoUid = "calysto-uid";
    const CalystoIsRepeater = "calysto-isrepeater";
    const CalystoIsGroup = "calysto-isgroup";
    const CalystoGetConvert = "calysto-getconvert";
    const CalystoSetConvert = "calysto-setconvert";
    const CalystoFormTarget = "calysto-form-target";
    const CalystoFormHandler = "calysto-form-handler";
    const CalystoFormMode = "calysto-form-mode";
    const CalystoFormDestination = "calysto-form-dest";
    const CalystoAppendVersion = "calysto-append-version";
    const CalystoSpinnerDelay = "calysto-spinner-delay";
    const CalystoTimeout = "calysto-timeout";
    const CalystoControllerAction = "calysto-controller-action";
    const CalystoScriptRun = "calysto-script-run";
}
declare namespace Calysto.Constants.CalystoAjaxHandlerConstants {
    const FileNameAddon = "-vr";
    const QueryStringEtagKey = "crixd";
    const StaticFileRequest = "~/";
    const HandlerBasePath = "calysto-handler";
    const ScriptResourceRequest = "calysto-handler-sc";
    const ElmahRequest = "calysto-handler-el";
    const TypeServiceRequest = "calysto-handler-ty";
    const AjaxGetParamName = "calysto-handler-aj";
}
declare namespace Calysto.Constants.BaseXCharsTable {
    const JavaScriptRFCTable64 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_!-";
    const StandardBase64RFC = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    const Table36JavaScriptRFC = "0123456789abcdefghijklmnopqrstuvwxyz";
}
/**
 * This is start file. It has no other references.
 * Next files should be resx files where this file has to be referenced at top.
 */
declare namespace Calysto.Globalization {
    class ResxExcelProvider {
        Table: DataTable;
        private _dataRows;
        get DataRows(): Dictionary<string, string[]>;
        GetDefaultSearchColumns(): string[];
        private GetSearchColumns;
        static FromJson(json: any): ResxExcelProvider;
        /**
         * Get cell value. As column use current culture name.
         * @param propertyName
         */
        GetString(propertyName: string): string;
        /**
         * Get cell value.
         * @param propertyName
         * @param columnName
         */
        GetString(propertyName: string, columnName: string): string;
        /**
         * Search multiple columns and get first non empty cell value.
         * @param propertyName
         * @param searchColumnsOrder
         */
        GetString(propertyName: string, searchColumnsOrder: string[]): string;
    }
}
declare namespace Calysto.Resources {
    interface CalystoLang {
    }
    class CalystoLang {
        static readonly ResourceProvider: Globalization.ResxExcelProvider;
        /** Jeste li sigurni? */
        static get AreYouSure(): string;
        /** Otkaži */
        static get Cancel(): string;
        /** Zatvori */
        static get Close(): string;
        /** Dan */
        static get Day(): string;
        /** Obriši */
        static get Delete(): string;
        /** Uredi */
        static get Edit(): string;
        /** Greška */
        static get Error(): string;
        /** Datoteka */
        static get File(): string;
        /** Informacija */
        static get Information(): string;
        /** Pronađena je novija verzija stranice.
Kliknite:
- Osvježi za osvježavanje i dohvat nove verzije
- Otkaži za zadržavanje na trenutnoj verziji */
        static get JavascriptEngineIsOutdatedInformation(): string;
        /** Poruka */
        static get Message(): string;
        /** Nemate dozvolu za ovu akciju */
        static get MethodInvocationFobidden(): string;
        /** Mjesec */
        static get Month(): string;
        /** Pronađena je novija verzija, stranica se osvježava... */
        static get NewVersionFoundPageIsReloading(): string;
        /** Ne */
        static get No(): string;
        /** U redu */
        static get OK(): string;
        /** Otvori */
        static get Open(): string;
        /** Molimo pričekajte, stranica se osvježava... */
        static get PageIsReloadingPleaseWait(): string;
        /** Molimo potvrdite */
        static get PleaseConfirm(): string;
        /** Pitanje */
        static get Question(): string;
        /** Osvježi */
        static get Reload(): string;
        /** Spremi */
        static get Save(): string;
        /** Uspješno */
        static get Success(): string;
        /** Danas */
        static get Today(): string;
        /** Upozorenje */
        static get Warning(): string;
        /** Tjedan */
        static get Week(): string;
        /** Godina */
        static get Year(): string;
        /** Da */
        static get Yes(): string;
    }
}
declare namespace Calysto {
    namespace DataBinder {
        function TryGetValue<T>(dataObj: Object, dataProperty: string | number, refOut: BoxValue<T>): boolean;
        function GetValue<T>(dataObj: Object, dataProperty: string | number): T;
        function SetValue(dataObj: Object, dataProperty: string | number, value: any): void;
    }
}
declare var Calysto_Core_RuntimeConstants: IRuntimeConstants;
declare namespace Calysto {
    class Core {
        static get Constants(): IRuntimeConstants;
        static get IsDebugDefined(): boolean;
        static get IsLocallyHosted(): boolean;
        static get IsTddSpecific(): boolean;
        /**
         * Run fn if debug is defined.
         * @param fn
         */
        static DebugRun(fn: () => void): void;
        /**
         * Register namespace in window object.
         * @param path
         */
        static RegisterGlobalNs(path: string): void;
        /**
         * Register obj to window as window[path] = object;
         * If path not provided, and obj is function, will use obj[name] as path
         * @param obj
         * @param path If not set, will use function.name. If can not resolve name, will throw exception.
         * @param mayOverwrite If namespace already exists:
         *		if true, will overwrite existing object in namespace
         *		else, will throw exception
         */
        static ExportGlobal(obj: any, path?: string, mayOverwrite?: boolean): void;
        /**
         * Using IDisposable item which is Disposed() at the end.
         * exapmple:
        let res1 = await Calysto.Core.UseDispose(new Tasks.CancellationTokenSource(3000), async token => await Tasks.TaskUtility.RunAsync(async () =>
        {
            await Tasks.TaskUtility.SleepAsync(1000);
            return 22;
        }, token));
         * @param item IDisposable object.
         * @param func Function to execute.
         */
        static UseDispose<TItem extends IDisposable, TResult>(item: TItem, func: (item: TItem) => TResult): TResult;
        static UseThis<TItem>(item: TItem, func: (item: TItem) => any): TItem;
        static UseTryCatch<TItem, TResult>(item: TItem, func: (item: TItem) => TResult, defaultResult?: TResult): TResult | undefined;
    }
}
declare namespace Calysto {
    const AttrName: typeof Constants.CalystoDomAttributes;
}
declare namespace Calysto {
    class BoxValue<T> {
        protected _value: T;
        protected _hasValue: boolean;
        constructor();
        SetValue(value: T): void;
        GetValue(): T;
        GetValueOrDefault(defaultValue: T): T;
        HasValue(): boolean;
        RemoveValue(): void;
    }
    class BoxValueObservable<T> extends BoxValue<T> {
        constructor();
        /**
         * Promisle like. If value is already set, will invoke callback delegate immediately.
        */
        readonly OnSetValue: IFuncMulticastDelegate<(value: T) => void, this>;
        /**
         * Set value, than invoke OnSetValue()
         * @param value
         */
        SetValue(value: T): void;
    }
}
declare namespace Calysto.Utility.Generators {
    /**
    * Generate alpha-numeric password.
    * Always starts with letter.
    * Contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
    * @param length
    */
    function GeneratePassword(length: number): string;
    /**
    * Generate new strong random password.
    * Contains lowercased letters, uppercased letters, digits and special chars.
    * @param length
    */
    function GenerateStrongPassword(length: number): string;
    /**
     * Generate new numeric password.
     * @param length
     */
    function GenerateNumericPassword(length: number): string;
    /**
    * Generate alpha-numeric label.
    * Always starts with letter.
    * Contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
    * @param length
    */
    function GenerateLabel(length: number): string;
}
declare namespace Calysto.ArraySorter {
    function SortArray<TItem, TKey>(arr: TItem[], keySelector?: (item: TItem) => TKey, descending?: boolean): any[];
}
declare namespace Calysto.Enum {
    /**
     * Get numeric value.
     * @param {TEnum} objEnum
     * @param {string} name
     * @returns
     */
    function GetValue<TEnum>(objEnum: TEnum, name: string): TEnum;
    /**
     * Get values as number[]
     * @param {TEnum} objEnum
     * @returns
     */
    function GetValues<TEnum>(objEnum: TEnum): TEnum[];
    /**
     * Test if numeric value exists in enum.
     * @param {TEnum} objEnum
     * @param {number} value
     * @returns
     */
    function HasValue<TEnum>(objEnum: TEnum, value: number): boolean;
    /**
     * Test if name exists in enum.
     * @param {TEnum} objEnum
     * @param {string} name
     * @returns
     */
    function HasName<TEnum>(objEnum: TEnum, name: string): boolean;
    /**
     * Get name as string from it's numeric value.
     * @param {TEnum} objEnum
     * @param {number} value
     * @returns
     */
    function GetName<TEnum>(objEnum: TEnum, value: number): string;
    /**
     * Get names as string[].
     * @param {TEnum} objEnum
     * @returns
     */
    function GetNames<TEnum>(objEnum: TEnum): string[];
}
declare namespace Calysto.Globalization {
    class DateTimeFormat {
        ShortestDayNames: string[];
        AbbreviatedDayNames: string[];
        DayNames: string[];
        AbbreviatedMonthNames: string[];
        MonthNames: string[];
        FirstDayOfWeek: 0;
        LongDatePattern: string;
        LongTimePattern: string;
        MonthDayPattern: string;
        ShortDatePattern: string;
        ShortTimePattern: string;
        GeneralLongTimePattern: string;
        GeneralShortTimePattern: string;
    }
    class NumberFormat {
        CurrencySymbol: string;
        NumberDecimalSeparator: string;
        NumberGroupSeparator: string;
        PerMilleSymbol: string;
        PercentSymbol: string;
        CurrencyPositivePattern: number;
        CurrencyPositivePatternString: string;
    }
    class Region {
        CurrencyEnglishName: string;
        CurrencyNativeName: string;
        CurrencySymbol: string;
        DisplayName: string;
        EnglishName: string;
        IsMetric: boolean;
        ISOCurrencySymbol: string;
        Name: string;
        NativeName: string;
        ThreeLetterISORegionName: string;
        ThreeLetterWindowsRegionName: string;
        TwoLetterISORegionName: string;
    }
    export class CultureInfo {
        Name: string;
        NativeName: string;
        DisplayName: string;
        EnglishName: string;
        ThreeLetterISOLanguageName: string;
        ThreeLetterWindowsLanguageName: string;
        TwoLetterISOLanguageName: string;
        DateTimeFormat: DateTimeFormat;
        NumberFormat: NumberFormat;
        Region: Region;
        constructor();
        static get Cultures(): {
            [name: string]: CultureInfo;
        };
        static get USCulture(): CultureInfo;
        static get HRCulture(): CultureInfo;
        /** get current culture */
        static get CurrentCulture(): CultureInfo;
        /** set new current culture */
        static set CurrentCulture(culture: CultureInfo);
    }
    export {};
}
declare namespace Calysto {
    export class CalystoEnumerable<TItem> {
        constructor(getEnumerator: () => CalystoEnumerator<TItem>);
        protected _getEnumerator: () => CalystoEnumerator<TItem>;
        GetEnumerator(): CalystoEnumerator<TItem>;
        AsEnumerable(): this;
        AsIterableIterator(): Generator<TItem, void, unknown>;
        ToArray(): TItem[];
        /**
         * Create new DOM enumerable query without converting to array first.
         * @returns
         */
        AsDomQuery(): DomQuery<TItem>;
        ToList(): List<TItem>;
        Count(): number;
        ToDictionary<TKey>(keySelector: (item: TItem) => TKey): Dictionary<TKey, TItem>;
        ToDictionary<TKey, TValue>(keySelector: (item: TItem) => TKey, valueSelector: (item: TItem) => TValue): Dictionary<TKey, TValue>;
        /**
         * Create {key: value, key1: value1}... If keys are not unique, will be overwriten.
         * @param keySelector
         */
        ToRawObject<TKey>(keySelector: (item: TItem) => TKey): {
            [P: string]: TItem;
        };
        /**
         * Create {key: value, key1: value1}... If keys are not unique, will be overwriten.
         * @param keySelector
         * @param valueSelector
         */
        ToRawObject<TKey, TValue>(keySelector: (item: TItem) => TKey, valueSelector: (item: TItem) => TValue): {
            [P: string]: TValue;
        };
        ToStringJoined(separator?: string): string;
        /**
         * Run foreach and return new enumerable
         * @param action
         */
        ForEach(action: (item: TItem, index: number) => void): CalystoEnumerable<TItem>;
        Skip(count: number): CalystoEnumerable<TItem>;
        Take(count: number): CalystoEnumerable<TItem>;
        Single(): TItem;
        /**
         * Take exact count. If there is more or less items in source, throw exception.
         * @param count
         */
        Exact(count: number): CalystoEnumerable<TItem>;
        /**
         * Computes the sum of numeric values the sequence.
         * @param selector
         */
        Sum<TNew>(selector?: (item: TItem) => TNew): TNew;
        /**
         * Computes average of non-null numeric values of the sequence: sum / count, count of numeric non-null values only.
         * @param selector
         */
        Average<TNew>(selector?: (item: TItem) => TNew): number;
        /**
         * Returns min value or null.
         * @param selector
         */
        Min<TNew>(selector?: (item: TItem) => TNew): TNew;
        /**
         * Returns max value or null.
         * @param selector
         */
        Max<TNew>(selector?: (item: TItem) => TNew): TNew;
        /**
         * Concatenates two sequences. (Is actually Idendical to the Array.concat method.)
         * @param secondSource
         */
        Concat(secondSource: CalystoEnumerable<TItem>): CalystoEnumerable<TItem>;
        /**
         * Concatenates two sequences. (Is actually Idendical to the Array.concat method.)
         * @param secondSource
         */
        Concat(secondSource: TItem[]): CalystoEnumerable<TItem>;
        /**
         * Include items from first where predicate(item1, item2){....} returns true
         * @param secondSource
         * @param predicate
         * @param excludeIntersection default: false
         */
        Intersect<TSecond>(secondSource: TSecond[] | CalystoEnumerable<TSecond>, predicate: (item1: TItem, item2: TSecond) => boolean, excludeIntersection?: boolean): CalystoEnumerable<TItem>;
        /**
         * Exclude items from first where predicate(item1, item2){....} returns true
         * @param secondSource
         * @param predicate
         */
        Except<TSecond>(secondSource: TSecond[] | CalystoEnumerable<TSecond>, predicate: (item1: TItem, item2: TSecond) => boolean): CalystoEnumerable<TItem>;
        /**
         * Join two sequences.
         * @param innerSource
         * @param outerKeySelector
         * @param innerKeySelector
         * @param resultSelector
         */
        Join<TInner, TKey, TResult>(innerSource: TInner[] | CalystoEnumerable<TInner>, outerKeySelector: (outer: TItem) => TKey, innerKeySelector: (inner: TInner) => TKey, resultSelector: (outer: TItem, inner: TInner) => TResult): CalystoEnumerable<TResult>;
        /**
         * Returns elements from a sequence as long as predicate returns true
         * @param predicate
         */
        TakeWhile(predicate: (item: TItem, index: number) => boolean): CalystoEnumerable<TItem>;
        /**
         * Skip elements from a sequence as long as predicate returns true, elements after that are selected.
         * @param predicate
         */
        SkipWhile(predicate: (item: TItem, index: number) => boolean): CalystoEnumerable<TItem>;
        Reverse(): CalystoEnumerable<TItem>;
        FirstOrDefault(defaultValue?: TItem | null): TItem | null | undefined;
        First(): TItem;
        LastOrDefault(defaultValue?: TItem | null): TItem | null | undefined;
        Last(): TItem;
        Any(predicate?: (item: TItem, index: number) => boolean): boolean;
        /**
         * Test if predicate returns true for all items in collection.
         * @param predicate
         */
        All(predicate: (item: TItem, index: number) => boolean): boolean;
        Where(predicate: (item: TItem, index: number) => boolean): CalystoEnumerable<TItem>;
        Select<TNew>(selector: (item: TItem, index: number) => TNew): CalystoEnumerable<TNew>;
        Cast<TNew>(): CalystoEnumerable<TNew>;
        SelectMany<TNew>(selector?: (item: TItem) => TNew[] | CalystoEnumerable<TNew>): CalystoEnumerable<TNew>;
        Distinct<TKey>(keySelector?: (item: TItem) => TKey): CalystoEnumerable<TItem>;
        /**
         * Cycle all elements in current collection to infinity.
         */
        Cycle(take: number): CalystoEnumerable<TItem>;
        GroupBy<TKey>(keySelector: (item: TItem) => TKey): CalystoEnumerable<CalystoGroupingGroup<TKey, TItem>>;
        OrderBy<TKey>(keySelector: (item: TItem) => TKey, descending?: boolean): CalystoOrderedEnumerable<TKey, TItem>;
        OrderByDescending<TKey>(keySelector: (item: TItem) => TKey): CalystoOrderedEnumerable<TKey, TItem>;
        static From<TItem>(source: ICalystoEnumerable<TItem> | CalystoEnumerable<TItem> | TItem[] | Iterator<TItem> | IterableIterator<TItem> | CalystoEnumerator<TItem> | (() => IterableIterator<TItem>)): CalystoEnumerable<TItem>;
        static Range(start: number, count: number): CalystoEnumerable<number>;
        static Repeat<TItem>(item: TItem, count: number): CalystoEnumerable<TItem>;
    }
    class CalystoGroupingGroup<TKey, TItem> extends CalystoEnumerable<TItem> {
        Key: TKey;
        constructor(Key: TKey, getEnumerator: () => CalystoEnumerator<TItem>);
    }
    class CalystoOrderedEnumerable<TKey, TItem> extends CalystoEnumerable<TItem> {
        private getGroupsEnumerator;
        constructor(getGroupsEnumerator: () => CalystoEnumerator<CalystoGroupingGroup<TKey, TItem>>);
        private GetFlatEnumerable;
        private GetGroupsEnumerable;
        ThenBy<TKey>(keySelector: (item: TItem) => TKey, descending?: boolean): CalystoOrderedEnumerable<TKey, TItem>;
        ThenByDescending<TKey>(keySelector: (item: TItem) => TKey): CalystoOrderedEnumerable<TKey, TItem>;
    }
    export {};
}
declare namespace Calysto.Collections {
    /**
     * Flattens any kind or argumens and any depth as long as they have length or GetEnumerator. Returns flattened array.
     * @param array
     */
    function SelectFlatten(array1: any, array2?: any, array3?: any, etc?: any): any[];
    function ForEach<TElement>(array: TElement[], delegate: (item: TElement, index: number) => void, context?: Object): void;
    function ForEachNodeList(array: NodeList, delegate: (item: Node, index: number) => void, context?: Object): void;
    function ForEachChars(str: string, delegate: (item: string, index: number) => void, context?: Object): void;
    function GetProperties(obj: Object, ownPropertiesOnly?: boolean): string[];
    function GetOwnProperties(obj: Object): string[];
    /**
     * Foreach all properties, not just ownProperties.
     * @param {Object} obj
     * @param {Function} delegate function(propName, propValue, index){...}
     * @param {Object} context?
     * @returns
     */
    function ForEachProperties<TValue>(obj: Object, delegate: (name: string, value: TValue, index: number) => void, context?: Object): void;
    /**
     * Foreach ownProperties only.
     * @param {Object} obj
     * @param {Function} delegate function(propName, propValue, index){...}
     * @param {Object} context
     * @returns
     */
    function ForEachOwnProperties<TValue>(obj: Object, delegate: (name: string, value: TValue, index: number) => void, context?: Object): void;
    function HasInnerArray(obj: any): any;
    function GetInnerArray<TItem>(obj: any): TItem[] | undefined;
}
interface Array<T> {
    /** Remove T item at index from this array and return this array */
    RemoveAt(index: number): Array<T>;
    /** Remove T item from this array and return this array */
    Remove(item: T): Array<T>;
    /**
     * Remove items from this array and return this array
     * @param predicate condition
     */
    RemoveBy(predicate: (item: T, index: number) => boolean): Array<T>;
    /** tests if item exists in this array */
    Contains(item: T): boolean;
    /**
     * creates and returns copy of current array
     */
    ToArray(): Array<T>;
    /**
     * returns true if array contains any element
     */
    Any(): boolean;
    /**
     * add elements to this array, returns this array
     * @param {Array<T>} arr
     */
    AddRange(arr: Array<T> | IArguments): Array<T>;
    /**
     * add new item to this array and return this array
     * @param {T} item
     */
    Add(item: T): Array<T>;
    /**
     * insert new items to this array and return this array
     * @param {number} atIndex
     * @param {Array<T>} arr
     */
    InsertRange(atIndex: number, arr: Array<T>): Array<T>;
    /**
     * Remove all items from this, return this array
     */
    Clear(): Array<T>;
    AsEnumerable(): Calysto.CalystoEnumerable<T>;
    /**
    * returns new array with sorted items by key
    */
    OrderBy<TKey>(keySelector: (item: T) => TKey, descending?: boolean): Array<T>;
    /** Run foreach on this array and returns this array. */
    ForEach(func: (item: T, index: number) => void): Array<T>;
    /**
    * In place reverse. Return this array.
    */
    Reverse(): Array<T>;
    /** join array elements to string, default separator is empty string "" */
    ToStringJoined(separator?: string): string;
}
declare namespace Calysto {
}
interface Blob {
    name: string;
    filename: string;
    blobIndex: number;
    /**
     * save blob to file
     * @param {string} filename
     */
    SaveFileAs(filename?: string): void;
}
interface Boolean {
    /**
     * returns string true or false
     */
    ToStringFormated(): string;
}
interface DateConstructor {
    FromLocalISOTString(dateStr: string): Date;
    ToLocalISOTString(date: Date): string;
}
interface ICalystoException {
    /**
        * short message
    */
    Message: string;
    /**
        * detailed message used in debug mode
    */
    Details: string;
    /**
        * details from server
    */
    HtmlDetails: string;
    /**
        * true if exception was thrown on server
    */
    IsServerError: boolean;
}
interface Error {
    CalystoException: ICalystoException;
    AppendErrorDetails(additionalInfo?: Object | String | Array<any>, isServerError?: boolean): Error;
    ToErrorEvent(): ErrorEvent;
}
interface Function {
    BindContext(context: any): Function;
}
declare namespace Calysto.Utility.Expressions {
    function ParsePath<TModel>(pathExpression: (m: TModel) => any): string;
    function CompileLambdaExpression(expression: Function | string | null | undefined): Function;
    function CompileLambdaNoReturnCheck(expression: Function | string | null | undefined): Function;
}
interface RegExpConstructor {
    /**
     * Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) and return string with escaped chars.
     * @param {string} str
     */
    Escape(str: string): string;
}
declare namespace Calysto.Utility {
    function Extend<TDestination>(destination: TDestination, source: object, mayOverwrite?: boolean, ownPropertiesOnly?: boolean): TDestination;
}
declare namespace Calysto.Type {
    enum JSType {
        String = 1,
        Boolean = 2,
        Decimal = 3,
        Number = 4,
        Integer = 5,
        Array = 6,
        Function = 7,
        DateTime = 8,
        Date = 9,
        NullOrUndefined = 10
    }
}
declare namespace Calysto.Type.NumberConverter {
    /**
     * Extract number from string and parse using current culture. Parse strOrNum and return number, if can't be parsed, return defaultValue
     * @param strOrNum
     * @param defaultValue default value to be returned if strOrNum is not number
     * @param decimalSeparator
     */
    function ToNumberOrDefault(strOrNum: any, defaultValue?: number, decimalSeparator?: string): any;
    /**
     * Extract number from string and parse using current culture. Parse strOrNum and return number, if can't be parsed, return defaultValue
     * @param strOrNum
     * @param defaultValue default value to be returned if strOrNum is not number
     * @param decimalSeparator
     */
    function ToDecimal(strOrNum: any, defaultValue?: number, decimalSeparator?: string): any;
    /**
     * Extract number from string and parse as float number using current culture, than convert to integer.
     * @param strOrNum
     * @param defaultValue
     */
    function ToInteger(strOrNum: any, defaultValue?: number): number | undefined;
    function ToBoolean(str: any, defaultValue?: boolean): any;
    /**
     * always returns string "" or default value +"" or ""
     * @param value
     * @param defaultValue
     */
    function ToString(value: any, defaultValue?: any): string;
}
declare namespace Calysto.Type.TypeConverter {
    /**
     * 	if obj is null or undefined or NaN, return empty string ""
        if exists obj.ToStringFormated, invoke obj.ToStringFormated(format), else, invoke ChangeType(obj, String).
     * @param obj
    * @param format eg.N1, N2, N0, dd.MM.yy HH: ss
     */
    function ToStringFormated(obj: any, format?: string): any;
    /**
     *
     * @param obj
     * @param toType
     * @param mayBeNull
     */
    function ChangeType(obj: any, toType: keyof typeof JSType, mayBeNull?: boolean): any;
    /**
     *
     * @param obj
     * @param toType
     */
    function ChangeType(obj: any, toType: TypeDescriptor): any;
    /**
     * Try to change obj to toTypeName, output result into refOutArray. Returns true if successful.
     * @param obj
     * @param toType
     * @param refOut
     */
    function TryChangeType<TResult>(obj: any, toType: keyof typeof JSType, refOut: BoxValue<TResult>): boolean;
}
declare namespace Calysto.Type {
    class TypeDescriptor {
        private _isNullable;
        private _typeName;
        /** underlaying type name, without ? mark */
        get UnderlayingTypeName(): string;
        get KnownTypeName(): JSType;
        /** Has ? mark: is nullable value type */
        get IsNullable(): boolean;
        /** nullable type name, with ? mark if type is nullable */
        get NullableTypeName(): string;
        /** is net type parsed successfuly*/
        get IsValidKnownType(): boolean;
        private static ResolveKnownTypeFromValue;
        /**
         *
         * @param typeName may be nullable with question mark, like in .NET, e.g. Integer?
         * @param isNullable
         */
        static FromTypeName(typeName: keyof typeof JSType, isNullable?: boolean): TypeDescriptor;
        static FromValue(value: any, isNullable?: boolean): TypeDescriptor;
    }
}
declare namespace Calysto.Type.TypeInspector {
    /**
     * for unittests
     * @param obj
     * @param property
     */
    export function ContainsProperty(obj: any, property: string): any;
    /**
     * is boolean
     * @param args
     */
    export function IsBoolean(...args: any[]): boolean;
    /**
     * is finite number, not NaN
     * @param args
     */
    export function IsNumber(...args: any[]): boolean;
    /**
     * is string
     * @param args
     */
    export function IsString(...args: any[]): boolean;
    /**
     * is system Array
     * @param args
     */
    export function IsArray(...args: any[]): boolean;
    /**
     * is DOM array
     * @param args
     */
    export function IsDomArray(...args: any[]): boolean;
    /**
     * is Array or DOM array
     * @param args
     */
    export function IsArrayOrDomArray(...args: any[]): boolean;
    /**
     * is functions with call and apply properties
     * @param args
     */
    export function IsFunction(...args: any[]): boolean;
    /**
     * is null or undefined or NaN
     * @param args
     */
    export function IsNullOrUndefined(...args: any[]): boolean;
    /**
     * Test if all values are valid string, number or boolean (excluding NaN, undefined and null of any type).
     * @param args
     */
    export function IsValueType(...args: any[]): boolean;
    /**
     * is Calysto.DateTime
     * @param value
     */
    export function IsDateTime(value: any): any;
    /**
     * is system Date
     * @param value
     */
    export function IsDate(value: any): any;
    export function Coalesce(...args: any[]): any;
    /**
    * 1. If references are equal, returns true.
    * 2. If JSON is not supported, return false.
    * 3. If references are not equal, serializes both object into JSON and compare json strings.
    * @param {any} obj1
    * @param {any} obj2
    * @returns
    */
    export function AreValuesEqual(obj1: any, obj2: any): boolean;
    interface IHashElement extends Object {
        __$$hash: string;
    }
    export function CalculateHashCode(obj: IHashElement): string;
    export {};
}
declare namespace Calysto.Mathm {
    /**
     * Generate rfc4122 version 4 compliant new GUID as function of current time and random number.
     * Returns string: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
    */
    function NewGuid(): string;
    /**
     * Returns random float value.
     * @param minVal inclusive min value, default: 0
     * @param maxVal exclusive max value, default: 1
     */
    function Random(minVal: number, maxVal: number): number;
    /**
     * Returns random int value.
     * @param minVal inclusive min value, default: 0
     * @param maxVal exclusive max value, default: 100
     */
    function RandomInt(minVal?: number, maxVal?: number): number;
    function DecimalFloor(num: number, decimalPlaces: number): number;
    function DecimalCeil(num: any, decimalPlaces: any): number;
    function DecimalRound(num: any, decimalPlaces: any): number;
    function DecimalTrunc(num: any, decimalPlaces: any): number;
}
interface Number {
    /**
     * Format number to string using Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat
     * @param format
     * nX to thousand separtor format with exact X decimal places
     * cX for currency thousand separtor format with exact X decimal places
     * #,##0.00## where zeros are mandatory and hashes are optional
     */
    ToStringFormated(format?: string): string;
}
interface StringConstructor {
    /**
     * Returns true if any of strings is null or empty or undefined
     * @param {string[]} ...args
     */
    IsNullOrEmpty(...args: string[]): boolean;
    /**
     * Returns true if any of strings is null or empty or white space only or undefined
     * @param {string[]} ...args
     */
    IsNullOrWhiteSpace(...args: string[]): boolean;
}
interface String {
    ToCharArray(): string[];
    Equals(str2: string, ignoreCase?: boolean): boolean;
    Trim(charsArray?: string[]): string;
    TrimStart(charsArray?: string[]): string;
    TrimEnd(charsArray?: string[]): string;
    ToNullIfEmpty(trim?: boolean): string;
    EndsWith(secondStr: string, ignoreCase?: boolean): boolean;
    StartsWith(secondStr: string, ignoreCase?: boolean): boolean;
    Contains(secondStr: string, ignoreCase?: boolean): boolean;
    Substring(startIndex: number, length?: number): string;
    Remove(startIndex: number): string;
    Repeat(count: number): string;
    TakeFirst(count: number, elipsis?: string, wordSplit?: boolean): string;
    TakeLast(count: number, elipsis?: string, wordSplit?: boolean): string;
    Split(splitCharsArr: string | string[], ignoreCase?: boolean): string[];
    ReplaceAll(search: string, replacement: string, ignoreCase?: boolean): string;
    ToNumber(): number;
    ToFunc(noReturnCheck: boolean): Function;
    GetHashCode(): number;
    /** single brackets: replace {Name} with value from object with property {Name: "john"} or {User.Name} with value from {User:{Name:"john"}} */
    FormatWith(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
    /** double brackets: replace {{Name}} with value from object with property {Name: "john"} or {{User.Name}} with value from {User:{Name:"john"}} */
    FormatWith2(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
    /** triple brackets: replace {{{Name}}} with value from object with property {Name: "john"} or {{{User.Name}}} with value from {User:{Name:"john"}} */
    FormatWith3(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
    AsEnumerable(): Calysto.CalystoEnumerable<string>;
    ToHtml(htmlEncode?: boolean): string;
}
declare namespace Calysto {
    class TimeSpan {
        private _ticks;
        constructor();
        /**
         * Returns ticks in milliseconds
         * @param {number} days
         * @param {number} hours
         * @param {number} minutes
         * @param {number} seconds
         * @param {number} milliseconds
         * @returns {type}
         */
        static GetTicks(days?: number, hours?: number, minutes?: number, seconds?: number, milliseconds?: number): number;
        static Create(days?: number, hours?: number, minutes?: number, seconds?: number, milliseconds?: number): TimeSpan;
        static FromMilliseconds(milliseconds: number): TimeSpan;
        static FromTicks(milliseconds: number): TimeSpan;
        static FromSeconds(seconds: number): TimeSpan;
        static FromMinutes(minutes: number): TimeSpan;
        static FromHours(hours: number): TimeSpan;
        static FromDays(days: number): TimeSpan;
        AddTicks(ticksMs: number): TimeSpan;
        AddDays(days: number): TimeSpan;
        AddHours(hours: number): TimeSpan;
        AddMinutes(minutes: number): TimeSpan;
        AddSeconds(seconds: number): TimeSpan;
        AddMilliseconds(milliseconds: number): TimeSpan;
        /** [float] The total number of milliseconds represented by this instance. */
        get TotalMilliseconds(): number;
        /** [float] The total number of seconds Ticks by this instance. */
        get TotalSeconds(): number;
        /** [float] The total number of minutes represented by this instance. */
        get TotalMinutes(): number;
        /** [float] The total number of hours represented by this instance.*/
        get TotalHours(): number;
        /** [float] The total number of days represented by this instance. */
        get TotalDays(): number;
        /** [long] The number of ticks contained in this instance. */
        get Ticks(): number;
        /** [int] The day component of this instance. The return value can be positive or negative. */
        get Days(): number;
        /** [int] The hour component of the current System.TimeSpan structure. The return value ranges from -23 through 23. */
        get Hours(): number;
        /** [int] The minute component of the current System.TimeSpan structure. The return value ranges from -59 through 59. */
        get Minutes(): number;
        /** [int] The second component of the current System.TimeSpan structure. The return value ranges from -59 through 59. */
        get Seconds(): number;
        /** [long] The millisecond component of the current System.TimeSpan structure. The return value ranges from -999 through 999. */
        get Milliseconds(): number;
        private pad;
        private static _token;
        private FormatTime;
        /**
         * use format or current culture ShortTimePattern
         * @param format
         */
        ToStringFormated(format?: string): any;
        toString(): any;
    }
}
declare namespace Calysto {
    /**
    * .NET DayOfWeek
    */
    enum DayOfWeek {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }
    namespace DateFormat {
        function Format(date: Date, format?: string, utc?: boolean): string;
        function TryParseExact(arg: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>, throwError?: boolean): boolean;
        var masks: {
            default: string;
            shortDate: string;
            mediumDate: string;
            longDate: string;
            fullDate: string;
            shortTime: string;
            mediumTime: string;
            longTime: string;
            isoDate: string;
            isoTime: string;
            isoDateTime: string;
            iso3DateTime: string;
            iso6DateTime: string;
            isoUtcDateTime: string;
        };
    }
    class DateTime {
        protected _typeName: string;
        private _dateItem;
        private get _isoDateStr();
        private get _currCultureStr();
        /** new instance with current datetime */
        constructor();
        /**
         * new instance FromLocalISOTString
         * @param date
         */
        constructor(date: string);
        /**
         * new instance from sytem Date
         * @param Date
         */
        constructor(date: Date);
        /**
         * new instance from DateTime
         * @param DateTime
         */
        constructor(dateTime: DateTime);
        /**
         * new instance from absolute ticks
         * @param ticks
         */
        constructor(ticks: number);
        AddHours(hours: number): DateTime;
        AddMinutes(minutes: number): DateTime;
        AddSeconds(seconds: number): DateTime;
        AddMiliseconds(misliseconds: number): DateTime;
        AddDays(days: number): DateTime;
        AddMonths(months: number): DateTime;
        AddYears(years: number): DateTime;
        /** to system Date object, create copy */
        ToSystemDate(): Date;
        /** to Calysto.DateTime, create copy */
        ToDateTime(): DateTime;
        ToStringFormated(format?: string): string;
        ToShortDateString(): string;
        ToLongDateString(): string;
        ToShortTimeString(): string;
        ToLongTimeString(): string;
        toString(): string;
        static get Now(): DateTime;
        /** The year, between 1 and 9999. */
        get Year(): number;
        /** The month component, expressed as a value between 1 and 12. */
        get Month(): number;
        /** The day component, expressed as a value between 1 and 31. */
        get Day(): number;
        /** NET DayOfWeek:
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        */
        get DayOfWeek(): DayOfWeek;
        /** The hour component, expressed as a value between 0 and 23. */
        get Hour(): number;
        /** The minute component, expressed as a value between 0 and 59.*/
        get Minute(): number;
        /** The seconds component, expressed as a value between 0 and 59. */
        get Second(): number;
        /** The milliseconds component, expressed as a value between 0 and 999. */
        get Millisecond(): number;
        /** The number of ticks that represent the date and time of this instance.
         * The value is between DateTime.MinValue.Ticks and DateTime.MaxValue.Ticks.*/
        get Ticks(): number;
        /** Gets the date component of this instance with time 00:00:00*/
        get Date(): DateTime;
        /** A time interval that represents the fraction of the day that has elapsed since midnight.*/
        get TimeOfDay(): TimeSpan;
        /**
         *
         * @param year e.g. 2017
         * @param month 1 - 12
         * @param day 1 - 31
         * @param hours 0 - 23
         * @param minutes 0 - 59
         * @param seconds 0 - 59
         * @param miliseconds 0 - 999
         */
        static Create(year: number, month: number, day: number, hours?: number, minutes?: number, seconds?: number, miliseconds?: number): DateTime;
        static TryParseDateTime(str: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>): boolean;
        static TryParseDate(str: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>): boolean;
        /**
         * Returns Calysto.DateTime, throw exception if can't be parsed.
         * @param {string} str
         * @param {string} format?
         * @returns
         */
        static ParseDateTime(str: string | Date | DateTime, format?: string, throwEx?: boolean): DateTime;
        /**
         * Returns Calysto.DateTime, date part only, throw exception if can't be parsed.
         * @param {string} str
         * @param {string} format?
         * @returns
         */
        static ParseDate(str: string | Date | DateTime, format?: string, throwEx?: boolean): DateTime;
    }
}
interface Date {
    ToStringFormated(format?: string): string;
    /** to system Date object, create copy */
    ToSystemDate(): Date;
    /** to Calysto.DateTime, create copy */
    ToDateTime(): Calysto.DateTime;
}
declare namespace Calysto {
    class KeyValue<TKey, TValue> {
        Key: TKey;
        Value: TValue;
        constructor(key: TKey, value: TValue);
    }
    class Dictionary<TKey, TValue> {
        private _map;
        constructor();
        AsEnumerable(): CalystoEnumerable<KeyValue<TKey, TValue>>;
        GetItems(): KeyValue<TKey, TValue>[];
        ToRawObject(errorOnDuplicateKey?: boolean): {};
        Clear(): void;
        RemoveKey(key: TKey): void;
        GetValues(): TValue[];
        GetKeys(): TKey[];
        Count(): number;
        ContainsKey(key: TKey): boolean;
        private AddKeyValue;
        Add(key: TKey, value: TValue): Dictionary<TKey, TValue>;
        SetValue(key: TKey, value: TValue): Dictionary<TKey, TValue>;
        TryGetValue(key: TKey, refOut: BoxValue<TValue>): boolean;
        GetValue(key: TKey): TValue;
        GetValueOrDefault(key: TKey, defaultValue?: TValue): TValue;
    }
}
declare namespace Calysto {
    interface ICalystoEnumerable<TElement> {
        GetEnumerator(): CalystoEnumerator<TElement>;
    }
    class CalystoEnumerator<TElement> {
        private fnYieldNext;
        constructor(fnYieldNext: (refYield: BoxValue<TElement>) => boolean);
        private current;
        YieldNext(refYield: BoxValue<TElement>): boolean;
        GetNext(): BoxValue<TElement>;
        MoveNext(): boolean;
        get Current(): TElement;
        static FromYieldFunc<TElement>(fnYieldNext: (refYield: BoxValue<TElement>) => boolean): CalystoEnumerator<TElement>;
        /**
        * From generator, function* (){ yield value; } with yield inside.
        * @param generatorFunc
        */
        static From<TElement>(generatorFunc: () => IterableIterator<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(getEnumerator: () => CalystoEnumerator<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(iterator: Iterator<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(iterableIterator: IterableIterator<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(array: TElement[]): CalystoEnumerator<TElement>;
        static From<TElement>(enumerable: ICalystoEnumerable<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(enumerable: CalystoEnumerable<TElement>): CalystoEnumerator<TElement>;
        static From<TElement>(enumerator: CalystoEnumerator<TElement>): CalystoEnumerator<TElement>;
        static From(source: string): CalystoEnumerator<string>;
    }
}
declare namespace Calysto.Features {
    enum BrowserKindEnum {
        Unknown = 0,
        Firefox = 1,
        Chrome = 2,
        Safari = 3,
        Opera = 4,
        MSIE = 5,
        Bot = 6,
        MobileBot = 7,
        iPhone = 8,
        AndroidMobile = 9,
        NokiaMobile = 10,
        WapPhone = 11,
        MobilePhone = 12,
        IEMobile = 13,
        iPad = 14,
        AndroidTablet = 15,
        iPod = 16,
        BlackBerry = 17,
        MSEdge = 18,
        ChromiumEdge = 19
    }
    enum OSKindEnum {
        Unknown = 0,
        Windows = 1,
        Macintosh = 2,
        Android = 3,
        Linux = 4,
        WindowsPhone = 5
    }
    function HasFlash(): boolean;
    function HasSilverlight(): boolean;
    function GetBrowser(): {
        /** True: if browser is detected, False: browser not detected	*/
        Found: boolean;
        KindName: string;
        Kind: BrowserKindEnum;
        Version: number;
        VersionString: string;
        IsCrawler: boolean;
        IsMobile: boolean;
        IsTablet: boolean;
        IsDesktop: boolean;
        HasTouch: boolean;
    };
    function GetOS(): {
        /** true: OS was detected, false: not detected */
        Found: boolean;
        Kind: OSKindEnum;
        KindName: string;
        Version: number;
        VersionString: string;
        WinName: string | null;
        iPhoneVersion: string | null;
    };
}
declare namespace Calysto.CookieUtility {
    /**
     * Set cookie value.
     * @param cookieName
     * @param cookieValue
     * @param expiresAfterSECONDS Number of seconds to keep cookie alive. If value not set or null, creates session cookie.
     * @param domain Domain with dot before: .domain.com or .www.domain.com
     * @param path Path, default /
     * @param secure Is secure
     */
    function SetCookieValue(cookieName: string, cookieValue: string, expiresAfterSECONDS?: number, domain?: string, path?: string, secure?: boolean): void;
    /**
     * Get cookie value by cookie name.
     * @param cookieName
     */
    function GetCookieValue(cookieName: string): string;
    /** Get all cookies as array of Name-Values: [{Name:c1, Value:v1}, {Name:c2, Value:v2},...] */
    function GetCookies(): {
        Name: string;
        Value: string;
    }[];
    /**
     * Delete cookie.
     * @param cookieName
     * @param domain
     */
    function DeleteCookie(cookieName: string, domain?: string): void;
}
interface ICalystoEventDefinition {
    element: Node;
    /** full name with namespaces after dot, eg: click.state-one.all-states, used for removal by name */
    eventFullName: string;
    /** event type string, without namespace, eg. click or focus */
    type: string;
    /** namespaces, array split by . */
    namespaces: string[];
    /** event handler function  function (ev) { } */
    callbackFunc: (this: HTMLElement, ev: Event) => void;
    /** function to remove event listener, function(){ } */
    removeEvent(): void;
    /** use capture, true/false */
    useCapture: boolean;
    /** passive, true/false */
    passive: boolean;
}
interface Node {
    /** Events assigned using Calysto.Event.Attach()
     * Event may be removed
    */
    $$calysto_EventsArr: ICalystoEventDefinition[];
}
declare namespace Calysto.Event {
    function IsSupported(eventType: string): boolean;
    function Attach(element: Node, eventFullName: string, callbackMethod: (this: HTMLElement, ev: Event) => void, useCapture?: boolean): ICalystoEventDefinition;
    function Detach(element: HTMLElement, eventFullName?: string, callbackMethod?: (this: HTMLElement, ev: Event) => void, useCapture?: boolean): void;
    function GetTarget(event: Event): EventTarget | null;
    function StopPropagation(event: Event, doStop: boolean): void;
    function GetOffsetToTarget(event: MouseEvent): {
        offsetX: any;
        offsetY: any;
    };
    function IsLeftMouseButton(event: MouseEvent): boolean;
    function IsRightMouseButton(event: MouseEvent): boolean;
    function IsMiddleMouseButton(event: MouseEvent): boolean;
    function IsAnyMouseButton(event: MouseEvent): boolean;
    function IsEnterKey(event: KeyboardEvent): boolean;
    function IsCtrlKey(event: KeyboardEvent): boolean;
    function IsShiftKey(event: KeyboardEvent): boolean;
    function IsEscKey(event: KeyboardEvent): boolean;
    function IsHoverChanged(element: Element, ev: MouseEvent, isHover: boolean): boolean;
    function DispatchEvent(el: Element, ev: Event | string, doc?: Document): void;
}
declare namespace Calysto.Utility.Html {
    function RemoveHtmlTags(html: string, replacement?: string): string;
    function ExtractAspNameOrId(aspNetIdOrName: string): string | undefined;
    function UrlEncode(str: string): string;
    function UrlDecode(str: string): string;
    function HtmlEncodeSimple(html: string): string;
    function HtmlDecodeSimple(html: string): string;
    function HtmlEncode(html: string): string;
    function HtmlDecode(html: string): string;
    function StringToHtml(str: string, htmlEncode?: boolean): string;
    function JavaScriptStringEncode(str: string): string;
    /**
     * Minify JS or CSS content.
     * @param jscode content string
     * @param kind default Full
     */
    function Minify(jscode: string, kind?: "Comments" | "Full"): string;
}
declare namespace Calysto.Utility.Encoding {
    export namespace Utf8CharsEncoder {
        /**
         * Encode chars in string into utf chars string
         * @param str
         */
        function EncodeUTF8(str: string): string;
        /**
         * Decore utf chars string into string
         * @param utftext
         */
        function DecodeUTF8(utftext: string): string;
    }
    export namespace UTF8 {
        function GetBytes(str: string): number[];
        function GetString(arr: number[] | Uint8Array): string;
    }
    export class CalystoBaseConverter {
        private charsTable;
        constructor(charsTable?: string);
        private ConvertBytes;
        private Convert;
        EncodeToBaseString(data: string | number[], toBits: number): string;
        DecodeBaseStringToArray(baseString: string, fromBits: number): number[];
        DecodeBaseStringToString(baseString: string, fromBits: number): string;
    }
    class CalystoHexConverter {
        private readonly converter;
        EncodeToHexString(data: string | number[]): string;
        DecodeHexStringToArray(hexString: string): number[];
        DecodeHexStringToString(hexString: any): string;
    }
    export var HEX: CalystoHexConverter;
    class CalystoBase64EncoderImpl {
        private converter;
        constructor(charsTable: string);
        EncodeToBase64String(data: string | number[]): string;
        DecodeBase64StringToArray(base64str: string): number[];
        DecodeBase64StringToString(base64str: string): string;
    }
    /** Standard base64 encoder*/
    export var RfcBase64: CalystoBase64EncoderImpl;
    /** Calysto base64 encoder for urls */
    export var CalystoBase64: CalystoBase64EncoderImpl;
    export var Base64RndEncoder: CalystoBase64EncoderImpl;
    export {};
}
declare namespace Calysto.Utility.Dom.Style {
    /**
     * Takes border-color and returns borderColor.
     * @param name
     */
    function ConvertCssNameToCamel(name: string): string;
    /**
     * Takes borderColor and returns border-color.
     * @param name
     */
    function ConvertCssNameFromCamel(name: string): string;
    /**
     * Set opacity.
     * @param element
     * @param value 0.0 - 1.0
     */
    function SetOpacity(element: HTMLElement, value: string | number): void;
    /**
     * Returns opacity percent value 0...100 or 100 if not set.
     * @param element
     */
    function GetOpacity(element: HTMLElement): number;
    function GetZIndex(element: HTMLElement): number;
    /**
     * Get zIndex from element or from the first ancestor where value is defined.
     * @param element
     */
    function GetZIndexNested(element: HTMLElement): number;
    class StyleDecodedValue {
        PropertyName: string;
        HasNumericValue(): boolean;
        NumericValue: number;
        private _styleValue;
        get StyleValue(): string;
        private CreateStyleValue;
        Units: string;
        Increment: string;
        IsIncrement(): boolean;
        IsPercent(): boolean;
        constructor();
        static Parse(styleValue: string | number, styleProperty?: string): StyleDecodedValue;
        ApplyNewValue(newValue: StyleDecodedValue): StyleDecodedValue;
    }
    /**
     * Calculate style value from currValue value corrected by newValue. Returns number.
     * If there is originalValue and newValue is in %, return percentage value of originalValue.
     * @param currValue numeric or string, with px, %, or no units
     * @param newValue new value or eg. +=10, auto, -=20, *=30, 10px, with px, % or no units
     */
    function CalculateNumericValue(currValue: number, newValue: string | number): number;
    function GetComputedStyleDeclaration(element: HTMLElement): CSSStyleDeclaration;
    /**
     * Get element style value if available, else get computed value.
     * @param element
     * @param stylePropName style property name
     */
    function GetComputedStyle(element: HTMLElement, styleProperty: string): StyleDecodedValue;
    /**
     * Set style value.
     * @param element
     * @param name
     * @param value can be string '+=10' which wil increment current value or '-=10" to decrement current value
     * @param units
     */
    function SetStyleValue(element: HTMLElement, name: string, value: any, units?: string): void;
}
declare namespace Calysto.Utility.Dom {
    export class ScrollHandler {
        private _currDeltaY;
        private _currDeltaX;
        HandleScroll(sender: HTMLDivElement, ev: WheelEvent): void;
    }
    export enum NodeTypeEnum {
        ELEMENT_NODE = 1,
        ATTRIBUTE_NODE = 2,
        TEXT_NODE = 3,
        CDATA_SECTION_NODE = 4,
        ENTITY_REFERENCE_NODE = 5,
        ENTITY_NODE = 6,
        PROCESSING_INSTRUCTION_NODE = 7,
        COMMENT_NODE = 8,
        DOCUMENT_NODE = 9,
        DOCUMENT_TYPE_NODE = 10,
        DOCUMENT_FRAGMENT_NODE = 11,
        NOTATION_NODE = 12
    }
    export function TrimSpaces(str: string): string;
    /**
     * Return element id. If doesn't exist, will create new id.
     * @param el
     */
    export function EnsureElementId(el: string | HTMLElement): string;
    /**
     * Test if element is visible in DOM, using style.display and offsetHeight and offsetWidht and style.visibility
     * @param element
     */
    export function IsElementVisible(element: Node): boolean;
    /**
     * Test if element and it's ancestors are visible in DOM.
     * @param element
     */
    export function IsDomTreeVisible(element: Node): boolean;
    /**
     * Returns true if el is in DOM. Traverse complete DOM tree from element to document root.
     * @param element
     */
    export function IsElementInDom(element: Node): boolean;
    /**
     * Test if element is child or descendant of parent or ancestor.
     * @param element
     * @param parent
     */
    export function IsDescendant(element: Node, parent: Node): boolean;
    /**
     * Get innerText or innerHtml with removed html tags or nodeValue.
     * @param element
     */
    export function GetInnerText(element: Node): string;
    export function HasTagName(obj: Element, tagName: string): boolean;
    export function GetViewportDiv(): HTMLDivElement;
    /**
     * Get element's position relative to visible viewport. {top:n, left:n, width:n, height:d}.
     * Position is measured from top left corner.
     * Bottom and right values are confusing. It is value from top left corner to the bottom or right side of element, not from bottom of the page.
     * @param element
     */
    export function GetElementScreenPosition(element: HTMLElement): {
        left: number;
        top: number;
        bottom: number;
        right: number;
        width: number;
        height: number;
    };
    /**
     * Get element's absolute position on page. {top:n, left:n, width:n, height:d}.
     * @param element
     */
    export function GetElementPagePosition(element: HTMLElement): {
        left: number;
        top: number;
        width: number;
        height: number;
    };
    export function GetScrollableAncestors(el: HTMLElement): HTMLElement[];
    export interface PageDimension {
        scrollLeft: number;
        scrollTop: number;
        scrollWidth: number;
        scrollHeight: number;
        clientWidth: number;
        clientHeight: number;
    }
    /**
     * Get current html page scroll dimensions as object: {scrollLeft:.., scrollTop:..., scrollWidth:..., scrollHeight:..., clientWidth:..., clientHeight:...}
     * scrollHeight: full height including scroll
     * scrollWidth: full width including scroll
    */
    export function GetPageDimensions(): PageDimension;
    class ElementViewPortPosition {
        private _element;
        constructor(el: HTMLElement);
        CalculatePoints(): {
            topLine: {
                name: string;
                vDistance: number;
            };
            rightLine: {
                name: string;
                hDistance: number;
            };
            bottomLine: {
                name: string;
                vDistance: number;
            };
            leftLine: {
                name: string;
                hDistance: number;
            };
        };
        /** Vertical distance from viewport, above or below, absolute value.
         * 0 means it is in viewport. */
        VerticalDistance(): number;
        /** Horizontal distance from viewport, left or right, absolute value.
         * 0 means it is in viewport. */
        HorizontalDistance(): number;
        IsInViewportVertical(allowPartial?: boolean): boolean;
        IsInViewportHorizontal(allowPartial?: boolean): boolean;
    }
    /**
    * Calculate element abslute distance from viewport.
    * @param el
    */
    export function GetElementViewportPosition(el: HTMLElement): ElementViewPortPosition;
    /**
     * Test if element is in visible viewport.
     * @param el
     * @param onlyPart if true, at least 1 dimension must be included in viewport, if false, all dimensions must be included
     */
    export function IsElementInViewport(el: HTMLElement, onlyPart: boolean): boolean;
    export type ClipDimension = {
        match?: RegExpMatchArray;
        useMargins?: boolean;
        top: number;
        right: number;
        bottom: number;
        left: number;
    };
    /**
     * Margins is Calysto specific, defines margin from top, right, bottom, left.
     * Rect is css standard, defined as left, right: from left, top, bottom: from top.
     * @param el
     * @param clipStyleString
     */
    export function ParseClip(el: HTMLElement, clipStyleString: string): ClipDimension;
    /**
     * Get element's current clip value.
     * clip: rect(0px 10px 100px 20px );
     * clip is always in px, all 4 values has to be set: top right bottom left
     * @param el
     */
    export function GetClip(el: HTMLElement): ClipDimension;
    /** define delta dimensions, ex: +=50 */
    type ClipDeltaDimensions = {
        top: string;
        right: string;
        bottom: string;
        left: string;
        useMargins?: boolean;
    };
    /**
     * Calculate clip. Used with animator.
     * @param el
     * @param newDim
     */
    export function CalculateClip(el: HTMLElement, newDim: string | ClipDeltaDimensions): ClipDimension;
    /**
     * Set clip. Not implemented.
     * @param el
     * @param clipValue e.g. already parsed into object or "margins(100% 0 0 0)" or "rect:(10px 100px 50px 53px)"
     */
    export function SetClip(el: HTMLElement, clipValue: string | {
        top: number;
        right: number;
        bottom: number;
        left: number;
        useMargins?: boolean;
    }): void;
    export function HasClass(obj: Element, cls: string): boolean;
    /**
     * Add css class, prevent duplicates.
     * @param obj
     * @param cls
     */
    export function AddClass(obj: Element, cls: string): void;
    /**
     * Remove class name or multiple class names.
     * @param obj
     * @param cls may contain multiple names separated by space
     */
    export function RemoveClass(obj: Element, cls: string): void;
    /**
     * Set exact cls value, removing all previous values.
     * @param obj
     * @param cls
     */
    export function SetClass(obj: Element, cls: string): void;
    export function ToggleClass(obj: Element, cls: string): void;
    export function GetAttributeNode(element: HTMLElement, attrName: string): Attr | null;
    /**
     * Returns attribute value as string or null if there is no attribute defined.
     * @param element
     * @param attrName
     */
    export function GetAttribute(element: Element, attrName: string): string | null;
    export function SetAttribute(element: Element, attrName: string, value: string): void;
    export function RemoveAttribute(element: Element, attrName: string): void;
    export function HasAttribute(element: Element, attrName: string): boolean;
    export function SetEnabled(element: HTMLElement, enabled: boolean): void;
    export function CloneNodeIfHasParent(node: Node): Node;
    export function RemoveNodeFromDom(node: Node): void;
    /**
     * Insert elements before refNode without cloning - remove elements from previous position.
     * @param refNode
     * @param elArray array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
     */
    export function InsertBefore(refNode: Node, elArray: Node[]): void;
    /**
     * Replace refNode with new one. refNode has to be in DOM, otherwise it won't work with replaceWith method.
     * @param refNode node which should be replaced
     * @param elArray array of replacement elements
     */
    export function ReplaceWith(refNode: Node, elArray: Node[]): void;
    /**
     * Insert elements after refNode without cloning - remove elements from previous position.
     * @param refNode
     * @param elArray array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
     */
    export function InsertAfter(refNode: Node, elArray: Node[]): void;
    /**
     * Replace parent's children with childrenArray.
     * @param parent
     * @param childrenArray If null, remove children only. Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
     */
    export function ReplaceChildrenWith(parent: Node, childrenArray: Node[]): void;
    /**
     * Add childrenArray to parent's children without cloning.
     * @param parent
     * @param childrenArray Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
     */
    export function AddChildren(parent: Node, childrenArray: Node[]): void;
    /**
     * Insert childrenArray as first child to parent node without cloning.
     * @param parent
     * @param childrenArray Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position.
     */
    export function InsertChildren(parent: Node, childrenArray: Node[]): void;
    export function ConvertToElementsArray(...args: any[]): HTMLElement[];
    /**
     * Center element into parent. Larger element is shrinked to fit into container.
     * @param element
     * @param crop false: fit larger dimension; true: overscan to fit smaller dimension
     * @param enlarge true: smaller element is enlarged to fit into parent, false: smaller element is not enlarged
     */
    export function CenterElementIntoParent(element: HTMLElement, crop?: boolean, enlarge?: boolean): void;
    /**
     * Select transform value of current elements and return new Calysto.List with string values.
     * @param node
     */
    export function SelectTransform(node: HTMLElement): string;
    export {};
}
declare namespace Calysto.Utility.Path {
    function GetQueryString(path: string): string;
    function GetFilePath(path: string): string;
    function GetExtension(path: string): string;
    function GetDirectoryName(path: string): string;
    function GetFileName(path: string): string;
}
declare namespace Calysto.Utility.Blob {
    interface IBlobResult {
        dataUrl: string;
        fileName: string;
    }
    /**
     *
     * @param byteArrays Uint8Array|Blob|File, example: [new Uint8Array([data]), new Blob(), new File(), ...]
     * @param contentType
     */
    function CreateBlob(byteArrays: any, contentType: string): Blob;
    function Base64ToBlob(base64Data: string, contentType: string): Blob;
    function DataUrlToBlob(dataUrl: string, filename: string): Blob;
    /**
     * convert blob to RFC base64 string
     * @param blob
     * @param onComplete
     */
    function BlobToBase64Async(blob: Blob): Promise<string>;
    /**
     * convert blob to string eg. data:image/png;base64,iVBORw0KGgoAAkJggg==
     * @param blob
     * @param onComplete
     */
    function BlobToDataUrlAsync(blob: Blob): Promise<IBlobResult>;
}
declare namespace Calysto.Utility.Caret {
    function SetInputSelectionRange(node: Node, start: number, end: number): void;
    function SetCaretPosition(node: Node, position: number): void;
    function GetCaretPosition(obj: Node): number | null;
    function GetInputSelectionRange(obj: Node): {
        start: number;
        end: number;
    } | null;
}
declare namespace Calysto.Utility.FullScreen {
    function RequestFullScreen(el: HTMLElement): void;
    function CancelFullScreen(): void;
    function GetFullScreenElement(): HTMLElement;
    function IsInFullscreen(): boolean;
    function IsIframeFullscreenEnabled(): boolean;
    function IsSupported(): boolean;
    function OnFullscreenChanged(handler: (sender: Document) => void): void;
    function OnFullscreenError(handler: (sender: Document) => void): void;
}
declare namespace Calysto.Utility.CalystoTools {
    function LongToByteArray(longNum: number, truncateEmptyBytes?: boolean): number[];
    function ByteArrayToLong(byteArray: number[] | Uint8Array): number;
}
declare namespace Calysto.Graphics {
    enum ResizeModeEnum {
        /** Default. Resize image to fit into rectangle without overflowing. Keep AR. */
        Fit = 0,
        /** Resize image to fit and overflow the rectangle bounds if required. Overflowing part of the image is croped. Keep AR.*/
        Crop = 1,
        /** Resize image to fit into rectangle without overflowing rectangle dimensions. Add background to create exact width and height. Keep AR */
        Exact = 2,
        /** Stretch to exact width and height, destroy AR */
        Stretch = 3,
        /** Reduce image if larger to fit into the rectangle without overflowing. Smaller images are left as-is without processing. Keep AR. */
        Reduce = 4
    }
    class ImageResize {
        constructor();
        /** max width */
        Width: number;
        /** max height */
        Height: number;
        Mode: keyof typeof ResizeModeEnum;
        Overscan: number;
        /** */
        BackColor: string;
        /** */
        OutputMime: string;
        Quality?: number;
        /**
         * Resize image and return dataURL
         */
        Resize(source: HTMLImageElement | HTMLCanvasElement | HTMLVideoElement): string;
    }
}
declare namespace Calysto {
    class QueryString {
        private urlStr?;
        /**
         * Create new instance from url if provided
         * @param url if provided, parse url
         */
        constructor(urlStr?: string | undefined);
        private items;
        private uri;
        GetInnerUri(): Uri;
        /**
         * Query string prefixed with question
         */
        GetQuery(): string;
        GetUrl(): string;
        Clear(): void;
        private FindItem;
        /**
         * case non-sensitive name search and add or update if exists
         * @param name
         * @param value
         */
        SetValue(name: string, value: string | any): this;
        /**
         * case non-sensitive name search and remove
         * @param name
         */
        RemoveValue(name: string): this;
        /**
         * case non-sensitve name search
         * @param name
         */
        GetValue(name: string): string | null;
        /**
         * Extract query part from url and parse it
         * @param url
         */
        private ParseImpl;
    }
}
declare namespace Calysto.ScriptLoader {
    /**
     * Return true if script is marked, return false if it was already marked and executed.
     * @param node
     */
    function MarkScriptExecuted(node: HTMLScriptElement): boolean;
    /**
     * Reload and execute script tag content, only if not already executed.
     * @param node
     */
    function ExecuteScriptNode(node: HTMLScriptElement, alwaysExecute?: boolean): false | HTMLElement;
    /**
     * Create and return script element.
     * @param scriptFileUrl
     * @param id
     */
    function LoadJSFile(scriptFileUrl: string, id?: string): HTMLScriptElement;
    /**
     * Return script element if created, else undefined.
     * @param scriptFileUrl
     * @param id
     */
    function LoadJsFileOnce(scriptFileUrl: string, id: string): HTMLScriptElement | undefined;
    function LoadJS(javascriptCode: string): HTMLScriptElement;
    function LoadCSSFile(cssFileUrl: string, id?: string): HTMLLinkElement;
    function LoadCSS(cssScriptCode: string, id?: string): HTMLStyleElement;
}
declare namespace Calysto {
    class Timer {
        private onTimeout?;
        constructor(onTimeout?: ((sender: Timer) => void) | undefined);
        private items;
        private sleepMs;
        private timeoutId;
        IsRunning(): boolean;
        Abort(): this;
        Start(delayMs: number): this;
        OnTimeout(func: (sender: Timer) => void): this;
    }
    class BussyTimer {
        private timeoutMs;
        private _expires;
        constructor(timeoutMs: number);
        Start(): this;
        Abort(): this;
        IsBussy(): boolean;
        /**
         * If timer is already bussy, returns true,
         * Else, set new timeout and return false.
         */
        IsBussyOrStart(): boolean;
    }
    class MouseTimer {
        private _timer;
        /**
         *  Default timeout 300ms.
         * @param timeoutMs default value: 300
         */
        constructor(timeoutMs?: number);
        /**
         * If timer is already bussy, returns true,
         * Else, set new timeout and return false.
         */
        IsDoubleclicked(): boolean;
    }
}
declare namespace Calysto {
    enum PartEnum {
        Scheme = 0,
        Host = 1,
        Port = 2,
        Path = 3,
        Query = 4,
        Hash = 5
    }
    export class Uri {
        /**
         * Create new instance from url.
         * @param url
         */
        constructor(url?: string);
        Scheme: string;
        Username: string;
        Password: string;
        Host: string;
        Port: string;
        Path: string;
        Query: string;
        Hash: string;
        CloneUri(startKind: PartEnum, endKind?: PartEnum): Uri;
        private BuildUri;
        /**Create scheme://host:port */
        GetSchemeHost(): string;
        /**Create scheme://host:port/path */
        GetSchemeHostPath(): string;
        /**Create complete URI with hash. */
        GetAbsoluteUri(): string;
        /** Relative url: /path?query#hash */
        GetPathQueryHash(): string;
        private ParseUrl;
    }
    export {};
}
declare namespace Calysto.Validate {
    /**
     *  Returns true if str is valid e-mail
     * @param str
     */
    function IsEmail(str: string): boolean;
    /**
     * Returns true if str is valid number formated in current culture, eg. - 43.634,634, but not - 43,53 kn (may include -,.0-9, no currency symbol)
     * @param str
     */
    function CanConvertToNumber(str: string): boolean;
    /**
     * same as IsNumber()
     * @param str
     */
    function CanConvertToDecimal(str: string): boolean;
    /**
     * Returns true if str is valid integer, eg. -34534 (may not include any other symbol)
     * @param str
     */
    function CanConvertToInteger(str: string): boolean;
    /**
     * Returns true if str contains valid number, eg. last - 43.634,634 kn
     * @param str
     */
    function ContainsNumber(str: string): boolean;
    /**
     * Is valid date formated in current culture.
     * @param str
     * @param format
     */
    function CanConvertToDate(str: string, format?: string): boolean;
    /**
     * Is valid dateTime in current culture.
     * @param str
     * @param format
     */
    function CanConvertToDateTime(str: string, format?: string): boolean;
    /**
     * Is valid IPv4 address d.d.d.d
     * @param str
     */
    function IsIPv4Address(str: string): boolean;
}
declare namespace Calysto {
    type Match = {
        /** true if match is successful, else false */
        Success: boolean;
        /** start position in original string */
        Index: number;
        /** length of match text */
        Length: number;
        /** complete match text value*/
        Value: string;
        /**Groups, 0 is complete match, 1,2,3... groups */
        Groups: RegExpMatchArray;
    };
    export class Regex {
        /**
         * Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) and return string with escaped chars.
         * @param str
         */
        static Escape(str: string): string;
        private regexPattern;
        private ignoreCase;
        constructor(regexPattern: string, ignoreCase?: boolean);
        private CreateRegex;
        private CreateMatchSegment;
        /**
         * Returns true if regex match is found
         * @param {string} inputStr
         * @returns
         */
        IsMatch(inputStr: string): boolean;
        /**
         * Returns IEnumerable of matched items
         * @param {string} inputStr
         * @param {number} startIndex?
         * @param {number} length?
         * @returns
         */
        SelectMatches(inputStr: string, startIndex?: number, length?: number): CalystoEnumerable<Match>;
        /**
         * Returns IEnumerable with matches and unmatches.
         * @param {string} inputStr
         * @param {number} startIndex?
         * @param {number} length?
         * @returns
         */
        SelectSegments(inputStr: string, startIndex?: number, length?: number): CalystoEnumerable<Match>;
        /**
         * Returns all matches as array.
         * @param {string} inputStr
         * @param {number} startIndex?
         * @param {number} length?
         * @returns
         */
        Matches(inputStr: string, startIndex?: number, length?: number): Match[];
        /**
         * Find and returns first match
         * @param {string} inputStr
         * @param {number} startIndex?
         * @param {number} length?
         * @returns
         */
        Match(inputStr: string, startIndex?: number, length?: number): Match | null;
        Replace(input: string, replacement: string): string;
    }
    export {};
}
declare namespace Calysto {
    interface CalystoCSSStyleRule extends CSSStyleRule {
        selectorArray: string[];
        selectorDic: Calysto.Dictionary<string, boolean>;
    }
    export class CalystoStyleSheet {
        constructor();
        private sheets;
        private disabledPrefix;
        Sheets(): CSSStyleSheet[];
        /**
         * Select rules by cssSelector. Will select disabled rules too.
         * @param cssSelector
         */
        SelectRules(cssSelector?: string): CalystoEnumerable<CalystoCSSStyleRule>;
        private GetIndex;
        private DeleteRule;
        /**
         * new rule will not have .selectorArray, so new selectorDic will be created to on next .Rules() invocation
         * @param rule
         */
        private RecreateRule;
        /**
         * Split multiple selectors. Create  new rule for each single selector
         * @param cssSelector
         */
        SplitSelectors(cssSelector: string): this;
        /**
         * Add new selector to existing rule.
         * @param cssSelector
         * @param newSelector
         */
        AddSelector(cssSelector: string, newSelector: string): this;
        /**
         * Remove cssSelector from rule, but leave rule with other selectors. If there is not more selectors left, will delete rule too.
         * @param cssSelector
         */
        RemoveSelector(cssSelector: string): this;
        AddRule(cssSelector: string, style: string): this;
        RemoveRules(cssSelector: string): this;
        DisableRules(cssSelector: string): this;
        EnableRules(cssSelector: string): this;
        ToCssText(separator: any): string;
        /**
         * Get all sheets from current document
         */
        static GetCurrent(): CalystoStyleSheet;
    }
    export {};
}
declare namespace Calysto.Json.Infrastructure {
    type CalystoJsonType = "Calysto_Blob" | "Calysto_Date" | "Calysto_Function";
    export interface IJsonItem {
        __calystotype: CalystoJsonType;
    }
    export class JsonBlob implements IJsonItem {
        /** (string) Base64 encoded data url */
        DataUrl: string;
        /** (int) Blob index when indexes are used instead of dataURL */
        BlobIndex: number;
        /** (string) FileName string */
        FileName: string;
        /** mime type */
        MimeType: string;
        /** (int), data length */
        Size: number;
        /** string */
        __calystotype: CalystoJsonType;
    }
    export class JsonDateTime implements IJsonItem {
        /**(string) ISO date string yyyy-MM-dd HH:mm:ss.fff */
        Date: string;
        /** string */
        __calystotype: CalystoJsonType;
    }
    export class JsonFunction implements IJsonItem {
        Function: string;
        __calystotype: CalystoJsonType;
    }
    export type UidWithBlobType = {
        UID: string;
        BLOB: Blob;
    };
    export type AsyncCompleteType = ({
        json: string;
        blobs: Blob[];
    });
    export type SerializerAsyncStateType = ({
        currentIndex: number;
        json: string;
        pureBlobs: Blob[];
        blobsCopy: UidWithBlobType[];
        useBlobIndex: boolean;
    });
    export const escapeeChars: {
        "\b": string;
        "\t": string;
        "\n": string;
        "\f": string;
        "\r": string;
        '"': string;
        "\\": string;
    };
    export {};
}
declare namespace Calysto.Json.Infrastructure {
    class CalystoJsonSerializer {
        private parts;
        private blobs;
        private indexes;
        private isAsync;
        private escapee;
        SerializeFunctions: boolean;
        constructor(isAsync?: boolean);
        private Write;
        private isArray;
        private isDate;
        private encodeString;
        private encodeArray;
        private createJsonDateTime;
        private serializeDate;
        private createJsonFunction;
        private serializeFunction;
        private createBlob;
        private serializeBlob;
        private asyncSerializeBlobsAsync;
        private serializeWithJsonStringify;
        private serializeWithCalysto;
        private serializeObject;
        SerializeAsync(objectToSerialize: any, recursionLimit: number, useBlobIndex: boolean): Promise<AsyncCompleteType>;
        Serialize(objectToSerialize: any, recursionLimit?: number): string;
    }
}
declare namespace Calysto.Json.Infrastructure {
    class CalystoJsonReader {
        private json;
        private blobsArray?;
        constructor(json: string, blobsArray?: Blob[] | undefined);
        private index;
        private currchar;
        private escapee;
        private Error;
        private Next;
        private Number;
        private String;
        private White;
        private Word;
        private Array;
        private Object;
        private Value;
        Parse(): any;
    }
}
declare namespace Calysto.Json {
    /**
     * public method: Calysto.JSON.PostConvertObject is used in DateTimeConverter.cs
     * @param obj
     * @param blobsArray
     */
    function fnJsonPostConvertObj2(obj: Infrastructure.IJsonItem, blobsArray?: Blob[]): Function | Date | Blob | Infrastructure.IJsonItem;
    /**
     * Serialize Blobs
     * @param objectToSerialize
     * @param recursionLimit
     * @param useBlobIndex true to create blob indexes inside JSON, false to create dataURL-s for blobs inside JSON
     */
    function SerializeAsync(objectToSerialize: any, recursionLimit?: number, useBlobIndex?: boolean): Promise<Infrastructure.AsyncCompleteType>;
    function Serialize(objectToSerialize: any, recursionLimit?: number): string;
    function Deserialize<TResult>(jsonString: string, blobsArray?: Blob[]): TResult;
}
declare namespace Calysto.Json {
    enum NodeTypeEnum {
        PrimitiveValue = 1,
        KeyValue = 2,
        ArrayValue = 3
    }
    class JsonNode {
        /** value type */
        readonly Type: NodeTypeEnum;
        readonly Parent: JsonNode;
        /** property in parent*/
        readonly Property: string;
        /** index in parent array */
        readonly Index: number;
        /** original JS object */
        readonly Value: any;
        /** depth from root */
        readonly Level: number;
        /**
         * Construct traversable tree node from js object.
         * @param value JS object
         * @param parent
         * @param property property in parent.Value
         */
        constructor(value: any, parent?: JsonNode, property?: string);
        constructor(value: any, parent?: JsonNode, index?: number);
        private ResolveType;
        Children(includeCurrent?: boolean): CalystoEnumerable<JsonNode>;
        Descendants(includeCurrent?: boolean): Calysto.CalystoEnumerable<JsonNode>;
        Ancestors(includeCurrent?: boolean): CalystoEnumerable<JsonNode>;
        Root(): JsonNode;
        /**
         * Select all nodes ih path.
         * Relative: prop2.prop3
         * Absolute: (at).prop1.prop2.prop3
         * @param path
         */
        SelectChain(path: string): CalystoEnumerable<JsonNode>;
    }
}
declare namespace Calysto.Json.BinaryFrame {
    function DeserializeAsync<TResult>(binaryData: Blob | ArrayBuffer | string): Promise<TResult>;
    function SerializeAsync(obj: any): Promise<BinaryFrameItem>;
    class BinaryFrameItem {
        Json: string;
        Blobs: Blob[];
        constructor(Json: string, Blobs: Blob[]);
        /**
         * Pack json and blobs into single binary data as Blob
         */
        ToBinaryData(): Blob;
    }
}
declare namespace Calysto.OverflowProvider {
    function CreateOverflow(): void;
    function RemoveOverflow(): void;
}
declare namespace Calysto {
    enum CloseMode {
        destroy = "destroy",
        hide = "hide"
    }
    enum DialogButton {
        XClose = "XClose",
        Yes = "Yes",
        No = "No",
        Cancel = "Cancel",
        Close = "Close"
    }
    enum DialogIcon {
        file = "file",
        edit = "edit",
        info = "info",
        error = "error",
        warning = "warning",
        question = "question",
        success = "success",
        none = "none"
    }
    enum DialogMode {
        /** default */
        Alert = 0,
        /** similar to bootstrap modal: hides page scrollbar and create scrollbar for dialog at the window right-most*/
        Panel = 1
    }
    /**
     * Font Awesome icon.
     * @param iconName
     */
    function GetFAIconClass(iconName: keyof typeof DialogIcon): "" | "fa-file" | "fa-edit" | "fa-check-circle" | "fa-times-circle" | "fa-exclamation-triangle" | "fa-info-circle" | "fa-question-circle";
    class Dialog {
        private _dialogControlEl;
        private _buttonsEl;
        private _xButtonEl;
        private _focusButtonEl;
        private _dialogBoxEl;
        private _windowEl;
        private _dialogBoxContainerEl;
        private _contentEl;
        private _maskEl;
        private _innerContentEl;
        private _titleEl;
        private _tdContentEl;
        private _titleText;
        private _initDone;
        private _isModal;
        private _iconName;
        private _closeOnEscKey;
        private _closeMode;
        private _viewMode;
        /**
         * creates new instance and append it to document body
         */
        constructor();
        Initialize(): void;
        GetDialogEl(): HTMLDivElement;
        GetContentEl(): HTMLDivElement;
        /**
         * Apply dialog width 100% and max-width:prefferedWidth in px
         * @param prefferedWidth
         */
        PrefferedWidth(prefferedWidth: number): this;
        Set(cb: (dialog: Dialog) => void): this;
        private RenderTitle;
        Title(title: string): this;
        Icon(iconName: keyof typeof DialogIcon): this;
        /**
        * Assign single callback, overwrite previous callback.
         * this inside fn is current Calysto.Dialog instance
         * @param {(buttonEl} fn
         * @param {string} buttonName
         * @param {function} ev
         * @returns
         */
        OnButtonClick: IFuncMulticastDelegate<(dialog: Calysto.Dialog, buttonName: DialogButton | string, ev: Event) => void, this>;
        /**
         * Assign single callback, overwrite previous callback.
         * Invoked when dialog is shown.
         * @param fn
         */
        OnShown: IFuncMulticastDelegate<(dialog: Calysto.Dialog) => void, this>;
        /**
         * Assign single callback, overwrite previous callback.
         * Invoked when dialog close is started.
        *	If action returns false, will abort closing action
         * @param fn
         */
        OnClosing: IFuncMulticastDelegate<(dialog: Calysto.Dialog) => void, this>;
        /**
         * Assign single callback, overwrite previous callback.
         * Invoked when dialog is removed from DOM.
         * @param fn
         */
        OnClosed: IFuncMulticastDelegate<(dialog: Calysto.Dialog) => void, this>;
        CloseMode(mode: keyof typeof CloseMode): this;
        private fnButtonClickHandler;
        private _buttons;
        /**
         * Hide all buttons, including X button
         */
        HideButtons(): this;
        ButtonXClose(): this;
        /**
         * XClose, OK, CANCEL, ...
         * @param name XClose, OK, CANCEL, ...
         * @param isDefault if true, focus button
         */
        Button(name: string, isDefault?: boolean): this;
        /**
         * Append content
         * @param content
         */
        AppendContent(content: string | HTMLElement): this;
        /**
         * Set content. Remove previous content.
         * @param content
         */
        Content(content: string | HTMLElement): this;
        /**
         * Set mask opacity (0.0 - 1.0), 1.0: full visibility
         * @param value 0.0 - 1.0 (full visibility = 1.0)
         */
        MaskOpacity(value: number): this;
        Background(value: string): this;
        private _intervalId;
        Close(): void;
        AutoClose(delayMs: number): this;
        private fnFixPosition;
        private fnFirstTimeInit;
        private fnShowWorker;
        private _closeOnMaskAssigned;
        CloseOnMaskClick(): this;
        CloseOnEscKey(): this;
        ViewMode(mode: DialogMode): this;
        /**
         * Show dialog in Calysto manner
         */
        Show(): this;
        /**
         * Return clicked button name.
         * @param closeOnClick Default true.
         */
        WaitButtonAsync(closeOnClick?: boolean): Promise<unknown>;
    }
}
declare namespace Calysto.Dialog {
    /**
     * Find Calysto.Dialog instance containing childElement
     * @param childEl
     */
    function FindDialog(childEl: HTMLElement): Calysto.Dialog;
    function ShowVersionExpired(): Dialog | undefined;
    function CreateInformation(msg: string, title?: string): Dialog;
    /**
     * Buttons have to be added. OnButtonClick has to be added. Show is already invoked.
     * @param msg
     * @param title
     */
    function CreateConfirm(msg: string, title?: string): Dialog;
    function CreateAlert(msg: string, iconName?: keyof typeof DialogIcon, title?: string): Dialog;
    function CreateError(msg: string, title?: string): Dialog;
    function CreateWarning(msg: string, title?: string): Dialog;
    function CreateSuccess(msg: string, title?: string): Dialog;
    function CreatePanel(): Dialog;
}
/*******************************************************************
function ShowDialog()
{
    new Calysto.Dialog()
    .Title("Warning")
    .Content("Carefull what are you doing!")
    .Button("Yes")
    .Button("No")
    .ButtonXClose()
    .Modal(true)
    .Icon("warning")
    .OnClick(function (dialog, buttonName)
    {
        if (buttonName == "XClose") dialog.Close();
        console.log("clicked: " + buttonName);
    })
    .Show();
}
*******************************************************************/
declare namespace Calysto {
    enum NotifyHPosition {
        center = "center",
        right = "right",
        left = "left"
    }
    enum NotifyVPosition {
        bottom = "bottom",
        top = "top"
    }
    class Notification {
        constructor(text: string);
        Text: string;
        VPosition: keyof typeof NotifyVPosition;
        HPosition: keyof typeof NotifyHPosition;
        Icon: keyof typeof DialogIcon;
        PrefferedWidth: number;
        AutoCloseMs: number;
        Set(fn: (notif: Notification) => void): this;
        private _containerEl;
        private _notifBoxEl;
        private _notifIconEl;
        private _notifContentEl;
        private _notifInnerEl;
        private _notifTextEl;
        private _notifCloseBtnEl;
        private EnsureContainer;
        private _template;
        private EnsureNotif;
        Show(): this;
        Hide(): void;
        static Create(text: string, icon?: keyof typeof DialogIcon, autoCloseMs?: number, vPosition?: keyof typeof NotifyVPosition, hPosition?: keyof typeof NotifyHPosition): Notification;
    }
}
declare namespace Calysto.Net {
    enum HttpStatusCode {
        ERR_NO_CONNECTION = 0,
        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102,
        EarlyHints = 103,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        Ambiguous = 300,
        MultipleChoices = 300,
        Moved = 301,
        MovedPermanently = 301,
        Found = 302,
        Redirect = 302,
        RedirectMethod = 303,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        RedirectKeepVerb = 307,
        TemporaryRedirect = 307,
        PermanentRedirect = 308,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        NotExtended = 510,
        NetworkAuthenticationRequired = 511
    }
}
declare namespace Calysto.Net {
    type EventDelegate = (sender: WebClient, ev: Event) => void;
    type ProgressEventDelegate = (sender: WebClient, ev: ProgressEvent) => void;
    class WebClient {
        url: string;
        static IsCrossdomain(url: string): boolean;
        static GetXMLHttpRequest(url: string): any;
        constructor(url: string);
        timeoutMs: number;
        responseType: string;
        async: boolean;
        xhr: XMLHttpRequest;
        private data;
        private headers;
        private isAborted;
        private isStarted;
        private listeners;
        SetTimeout(timeoutMs: number): this;
        SetUrl(url: string): this;
        SetAsync(isAsync: boolean): void;
        private CreateData;
        private CreateNameValue;
        UploadDictionary(dic: Object): this;
        UploadString(str: string): this;
        UploadJson(json: string): this;
        UploadData(data: object | Function): this;
        UploadHtmlForm(form: HTMLFormElement, appendKeys?: {
            Key: string;
            Value: string;
        }[]): this;
        UploadFile(file: File, fileName?: string): this;
        /**
         * Set response type
         * @param typeString possible values:  "", "text", "arraybuffer", "blob", "document", "json", if not set, default is "text"
         */
        SetResponseType(typeString?: "text" | "arraybuffer" | "blob" | "document" | "json" | ""): this;
        AddRequestHeader(name: string, value: string): this;
        Abort(): this;
        /** Start download if not already started. */
        Start(): WebClient;
        DownloadDataAsync<TResult>(): Promise<TResult>;
        DownloadStringAsync(): Promise<string>;
        GetResponseText(): string;
        GetResponse(): any;
        private GetLiistenersItem;
        private AddCallback;
        OnUploadAbort(func: EventDelegate): this;
        OnUploadError(func: EventDelegate): this;
        /**
         * Upload complete.
         * @param func
         */
        OnUploadLoad(func: EventDelegate): this;
        /**
         * 	Use e.loaded and e.total<br/>
            Property 'e.position' is deprecated. Please use 'e.loaded' instead.<br/>
            Property 'e.totalSize' is deprecated. Please use 'e.total' instead.
         * @param func function(sender, e){...}
         */
        OnUploadProgress(func: ProgressEventDelegate): this;
        OnUploadTimeout(func: EventDelegate): this;
        OnReadyStateChange(func: EventDelegate): this;
        OnAbort(func: EventDelegate): this;
        OnError(func: EventDelegate): this;
        /**
         * Download complete, any status code, successful or error.
         * @param func
         */
        OnLoad(func: EventDelegate): this;
        /** Download progress.
         * 	Use e.loaded and e.total<br/>
            Property 'e.position' is deprecated. Please use 'e.loaded' instead.<br/>
            Property 'e.totalSize' is deprecated. Please use 'e.total' instead.
         * @param func function(sender, e){...}
         */
        OnProgress(func: ProgressEventDelegate): this;
        /**
         * Download timeout.
         * @param func
         */
        OnTimeout(func: EventDelegate): this;
    }
}
declare namespace Calysto.Net {
    type FuncDelegate = () => void;
    type MessageDelegate = (socketMsg: any) => void;
    type ErrorDelegate = (errMsg: string) => void;
    export class CalystoWebSocket {
        /** eg. /files/path.aspx */
        private virtualPath;
        constructor(
        /** eg. /files/path.aspx */
        virtualPath: string);
        private ws;
        private receiveBuffer;
        private sendQueue;
        /** Add new callback after socket opened. */
        readonly OnOpen: IFuncMulticastDelegate<FuncDelegate, this>;
        /** Callback after socket closed */
        readonly OnClose: IFuncMulticastDelegate<FuncDelegate, this>;
        readonly OnError: IFuncMulticastDelegate<ErrorDelegate, this>;
        /** Callback on message received*/
        readonly OnMessage: IFuncMulticastDelegate<MessageDelegate, this>;
        OpenAsync(): Promise<CalystoWebSocket>;
        private isSending;
        SendAsync(item: any): Promise<this | undefined>;
        IsOpened(): boolean;
        Close(): this;
    }
    export {};
}
declare namespace Calysto.Net.WebService {
    type FNReturnValueCallbackDelegate = (value: any) => void;
    type FNErrorCallbackDelegate = (errMsg: string, errDetails?: string | object, isServerError?: boolean) => void;
    type FNResponseReceivedCallbackDelegate<TReturn> = (container: IWebServiceResponseContainerWithReturn<TReturn>) => void;
    type StateTypeSmall<TReturn> = {
        /** execute before any other callback, if PreventDefault is true, invoke OnEnd and stop processing any more events */
        fnResponseContainerCallback: FNResponseReceivedCallbackDelegate<TReturn>;
        fnResponseEndCallback: () => void;
        fnReturnValueCallback: FNReturnValueCallbackDelegate;
        fnErrorCallback: FNErrorCallbackDelegate;
    };
    type StateTypeFull = StateTypeSmall<any> & {
        wclient: WebClient;
        responseContainer: IWebServiceResponseContainerWithReturn<any>;
        httpStatus: number;
        isErrorStatus: boolean;
        contentType: string;
        isHtml: boolean;
        isJson: boolean;
        calystoType: string;
        arrayBuffer: ArrayBuffer;
        blob: Blob;
        respTxt: string;
        errorText: string;
        errorDescription: string;
        errorHtml: string;
    };
}
declare namespace Calysto.Net.WebService {
    type cbTypes = "OnAbort" | "OnProgress" | "OnResponse" | "OnSuccess" | "OnEnd" | "OnError";
    export abstract class AjaxServiceClientBase {
        /**Abort request */
        Abort(): this;
        readonly OnAbort: IFuncMulticastDelegate<(msg: string) => void, this>;
        /**promisse, callback on upload or download progress changed*/
        readonly OnProgress: IFuncMulticastDelegate<(ev: ICalystoProgressEvent) => void, this>;
        /**promisse, callback on ajax request is complete, after OnSuccess, but before OnError*/
        readonly OnEnd: IFuncMulticastDelegate<() => void, this>;
        /**promisse, callback on error response received */
        readonly OnError: IFuncMulticastDelegate<(err: string) => void, this>;
        private _values;
        /**
         * Add value to cache and invoke delegate.
         * @param name
         * @param value
         */
        protected SetValue(name: cbTypes, value: any): void;
        /**
         *  If value already exists, invoke delegate.
         * @param name
         * @param fn
         */
        protected TryInvokeValue(name: cbTypes, fn: Function): void;
    }
    export class AjaxServiceClientVoid extends AjaxServiceClientBase {
        /**invoke when response is received, before it is read*/
        readonly OnResponse: IFuncMulticastDelegate<(container: IWebServiceResponseContainer) => void, this>;
        /**promisse, callback on successful response received*/
        readonly OnSuccess: IFuncMulticastDelegate<() => void, this>;
        ResultAsync(): Promise<void>;
    }
    export class AjaxServiceClientWithReturn<TResult> extends AjaxServiceClientBase {
        /**invoke when response is received, before it is read */
        readonly OnResponse: IFuncMulticastDelegate<FNResponseReceivedCallbackDelegate<TResult>, this>;
        /**promisse, callback on successful response received*/
        readonly OnSuccess: IFuncMulticastDelegate<(resp: TResult) => void, this>;
        ResultAsync(): Promise<TResult>;
    }
    export {};
}
declare namespace Calysto.Net.WebService {
    interface ICalystoProgressEvent {
        /**
            false: download progres<br/>
            true: upload progress
         */
        IsUpload: boolean;
        /** is length computable */
        IsComputable: boolean;
        /** loaded bytes count */
        Loaded: number;
        /** total bytes length*/
        Total: number;
        /** Percent (0-100), Loaded/Total */
        Percent: number;
    }
}
declare namespace Calysto.Net.WebService {
    /** u C# postoji class SocketServiceRquestContainer */
    interface ISocketServiceRequestContainer {
        /** method name */
        Method: string;
        /** object to send */
        RequestObj: any;
        /**unique message reference */
        ReferenceGuid: string;
        /** socket echo message */
        EchoMsg: string;
    }
}
declare namespace Calysto.Net.WebService {
    interface ISocketWebRequestArguments {
        /** ajax request over socket*/
        IsSocketWebClient: boolean;
        /** used for ajax request over socket */
        AjaxQueryString?: string;
        /** used for ajax request over socket */
        AjaxArgs: {
            [x: string]: object;
        };
    }
}
declare namespace Calysto.Net.WebService {
    /** istoimeni tip postoji u C# */
    interface IWebServiceResponseContainer {
        /** true if server method invoked without exception thrown, returning void or value */
        IsSuccessful?: boolean;
        /** "IWebServiceResponseContainer" */
        Type?: "IWebServiceResponseContainer";
        /** */
        IsEngineExpired?: boolean;
        /**execute javascript */
        JavaScriptLO?: string;
        /** once the JavaScriptLO is used, mark it as done to prevent double execution */
        IsJavaScriptLODone: boolean;
        /** short message */
        ExceptionMessage?: string;
        /** once the ExceptionMessage is used, mark it as done to prevent double execution */
        IsExceptionMessageDone: boolean;
        /** detailed message */
        ExceptionDetails?: string;
        /** method name on server */
        Method?: string;
        /**unique message reference */
        ReferenceGuid: string;
        /** socket echo message */
        EchoMsg: string;
    }
}
declare namespace Calysto.Net.WebService {
    interface IWebServiceResponseContainerWithReturn<TReturn> extends IWebServiceResponseContainer {
        /** value returned from Method on server */
        ReturnedValue: TReturn;
    }
}
declare namespace Calysto.Net.WebService {
    /** C# postoji class WebServiceSettings */
    interface IWebServiceSettings {
        /** [int] ms, default 90000 */
        timeoutMs?: number;
        /** [bool] use asp.net session state */
        sstate?: boolean;
        /**
            [bool] If true, will not count ajax request and none of events connected with count will not be invoked
            e.g. (Calysto.Page.OnLoading, Calysto.Page.OnBeginRequest, Calysto.Page.OnEndRequest).
        */
        silent?: boolean;
        /** string[], method arguments names: ["arg1", "arg2", etc]*/
        argNames?: string[];
        /** [string] method name*/
        method: string;
        /** [bool] if true, method may be invoked only on user event on client */
        reque?: boolean;
        /** [bool] if true, will always use POST to send data to server */
        post?: boolean;
    }
}
declare namespace Calysto.Net.WebService {
    class WebSocketSession<TBroadcastMessage> {
        /**settings is unique per method*/
        private settings;
        /** socket instance may be shared among methods*/
        Socket: CalystoWebSocket;
        constructor(
        /**settings is unique per method*/
        settings: IWebServiceSettings, 
        /** socket instance may be shared among methods*/
        Socket: CalystoWebSocket);
        private HandleSocketMessageAsync;
        private ProcessResponseAsync;
        readonly OnBroadcastMessage: IFuncMulticastDelegate<(resp: TBroadcastMessage) => void, this>;
        readonly OnError: IFuncMulticastDelegate<(errMsg: string) => void, this>;
        private _pendingCallbacks;
        OnMethodReturn(requestGuid: string, context: AjaxServiceClientWithReturn<any>): void;
    }
}
declare namespace Calysto.Net.WebService {
    function Log(msg: any): void;
    function EngineExpired(): void;
    function CreateUrl(vpath: string, settings: IWebServiceSettings): string;
    function CreateArgsObj(methodName: string, argsValues: any[], argNames: string[]): {};
    /**test if event is triggered by user action */
    function IsTriggeredByUserAction(): boolean;
    function CreateFullStateObj(sender: WebClient, state: StateTypeSmall<any>): StateTypeFull;
    function ReadArrayBufferAsync(state: StateTypeFull): Promise<void>;
    function ProcessResponseContainer(responseContainer: IWebServiceResponseContainerWithReturn<any>, state: StateTypeSmall<any>): void;
    function ProcessResponse(state: StateTypeFull): void;
    function AjaxResponseReceivedHandlerAsync(wclient: WebClient, state1: StateTypeSmall<any>): Promise<void>;
}
declare namespace Calysto.Net.WebService {
    class WebAjaxServiceHelper {
        /**complete service namespace including C# class name*/
        private namespace;
        private url;
        private vpath;
        private ns;
        constructor(
        /**complete service namespace including C# class name*/
        namespace: string, 
        /**service url*/
        url: string);
        RegisterAjaxMethod(settings: IWebServiceSettings): WebAjaxServiceHelper;
    }
}
declare namespace Calysto.Net.WebService {
    class WebSocketSessionHelper {
        /**complete service namespace including C# class name*/
        private namespace;
        private ns;
        private vpath;
        private methods;
        constructor(
        /**complete service namespace including C# class name*/
        namespace: string, 
        /**service url*/
        url: string);
        RegisterSocketMethod(settings: IWebServiceSettings): WebSocketSessionHelper;
    }
}
declare namespace Calysto.Net.WebService {
    function CreateAjax(namespace: string, url: string): WebAjaxServiceHelper;
    function CreateSocket(namespace: string, url: string): WebSocketSessionHelper;
}
declare namespace Calysto {
    export interface IFuncMulticastDelegate<TDelegate extends Function, TOwner> {
        /**Add callback delegate.*/
        (fn: TDelegate): TOwner;
        /** Underlaying MulticastDelegate<TDelegate> instance */
        readonly MCD: MulticastDelegate<TDelegate>;
        Invoke(action?: (delegate: TDelegate) => void): void;
        Any(): boolean;
    }
    class CallbackItem<TDelegate extends Function> {
        delegate: TDelegate;
        executedCount: number;
        executionsMax: number;
        doCountExecutions: boolean;
        ForRemoval(): boolean;
    }
    /**
     * TFunc example: (ime: string, age: number)=>void
     */
    export class MulticastDelegate<TDelegate extends Function> {
        protected items: CallbackItem<TDelegate>[];
        protected onAddHandlers: ((delegate: TDelegate) => void)[];
        protected onInvokeHandlers: ((delegate: TDelegate) => void)[];
        constructor();
        /**
         * Invode after every Add() invoked
         * @param func
         */
        OnAdd(func: (delegate: TDelegate) => void): this;
        /**
         * Invoke after every Invoke() invocation
         * @param func
         */
        OnInvoke(func: (delegate: TDelegate) => void): this;
        /**
         *
         * @param delegate
         * @param executionsMax maximum times to be executed, than ignore it
         */
        Add(delegate: TDelegate, executionsMax?: number): this;
        /**
         * Remove items by delegate.
         * @param delegate
         */
        Remove(delegate: TDelegate): this;
        /**
         * Will invoke delegate only once.
         * @param delegate
         */
        AddOnce(delegate: TDelegate): this;
        /**
         * Will invoke delegate executionsMax times.
         * @param executionsMax
         * @param delegate
         */
        AddCount(executionsMax: number, delegate: TDelegate): this;
        /**
         * invoke every delegate with parameters, e.g. f=>f(1,2,3);
         * @param action
         */
        Invoke(action?: (delegate: TDelegate) => void): void;
        Any(): boolean;
        Count(): number;
        Clear(): this;
        private _asFuncCached;
        /**
         * encapsulate and return Add function, instead mc.Add(()=>{}), than we may left out .Add and use md(()=>{})
         * shorthand method md(()=>{}) returns owner instance, instead of MulticastDelegate instance
         * feature is used in ajax callbacks .OnSuccess().OnError()... () returns TOwner
         * encapsulated () returns owner
         * @returns owner
         */
        AsFunc<TOwner>(owner?: TOwner): IFuncMulticastDelegate<TDelegate, TOwner>;
        private CopyFunction;
    }
    export {};
}
declare namespace Calysto.Page {
    var IsPageReloading: boolean;
    var IsVersionExpiredVisible: boolean;
    /**
     * Execute once at window.onload event (or document.readyState=='complete'). Includes clasic page load only.
     */
    const OnLoadComplete: IFuncMulticastDelegate<() => void, typeof Page>;
    /**
        Executes on:
        1. Page unload by navigating to different url
        2. MS classic postback start
        3. MS ajax postback start
        4. Calysto ajax start request
     */
    const OnLoading: IFuncMulticastDelegate<(isLoading: boolean) => void, typeof Page>;
    /**
        Executes on:
        1. Page unload by navigating to different url
        2. MS classic postback start
        3. MS ajax postback start
        4. Calysto ajax start request
     */
    const OnBeginRequest: IFuncMulticastDelegate<() => void, typeof Page>;
    /**
        Executes on:
        1. Page load or interactive
        2. MS classic postback end response
        3. MS ajax end response
        4. Calysto ajax end response
     */
    const OnEndResponse: IFuncMulticastDelegate<() => void, typeof Page>;
    /**
     * Execute once on document.readyState=='interactive' or page load. It is as soon as html is interactive, but all other resources may not be loaded (eg. images)
     * @param func
     */
    const OnInteractive: IFuncMulticastDelegate<() => void, typeof Page>;
    /**
     * Accepts function(errMsg){...} where errMsg is sent from the system.
     */
    const OnUnhandledException: IFuncMulticastDelegate<(errMsg: string) => void, typeof Page>;
    /**
     * Executes when JS engine version is outdated. This command is returned from server
     * errMsg is sent from the system
     * warning: must be MulticastDelegate because .Any() is used in EngineExpiredJS on server
     */
    const OnVersionExpired: IFuncMulticastDelegate<() => void, typeof Page>;
    /**
    * Accepts function(sender, ev){...} where sender is document
    */
    const OnEscKey: IFuncMulticastDelegate<() => void, typeof Page>;
}
declare namespace Calysto.Page.Social.Facebook {
    export interface fbProfile {
        error: string;
        email: string;
        first_name: string;
        id: string;
        last_name: string;
        name: string;
        picture: fbPicture;
    }
    export interface fbPicture {
        error: string;
        data: fbPictureData;
    }
    export interface fbPictureData {
        height: number;
        is_silhouette: boolean;
        url: string;
        width: number;
    }
    export interface fbPermissions {
        error: string;
        data: fbPermissionsItem[];
    }
    export interface fbPermissionsItem {
        permission: string;
        status: string;
    }
    class FacebookData {
        constructor();
        get FB(): fb.FacebookStatic;
        StatusResponse: fb.StatusResponse;
        Profile: fbProfile;
        Picture: fbPicture;
        Permissions: fbPermissions;
    }
    export class FacebookProvider {
        private facebookAppId;
        private scope?;
        Data: FacebookData;
        Error: any;
        private constructor();
        static _cache: Map<string, FacebookProvider>;
        static GetProvider(facebookAppId: string, scope?: string): FacebookProvider;
        /**
         * Load FB SDK.
         * @param cancellationToken
         */
        InitEngine(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        /**
         * Load FB SDK scripts and invoke FB.init() with current app (current facebookAppId).
         * @param cancellationToken
         */
        InitApp(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        GetLoginStatus(cancellationToken?: Tasks.CancellationToken): Promise<fb.StatusResponse | null>;
        /** Is current user authenticated with current app (current facebookAppId) */
        IsAuthenticated(): Promise<boolean | null>;
        /** Is current user authenticated to his FB account */
        IsFbAuthenticated(): Promise<boolean>;
        /**
         * Login to current app (current facebookAppId)
         * default scope: public_profile,email
         * @param scope additional scope
         */
        Login(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        LoadProfile(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        LoadPicture(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        LoadPermissions(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
    }
    export {};
}
declare namespace Calysto.Page.Social.Google {
    interface googleBasicProfile {
        Id: string;
        Name: string;
        GivenName: string;
        FamilyName: string;
        ImageUrl: string;
        Email: string;
    }
    interface googleAuthData {
        AuthResponse: gapi.auth2.AuthResponse;
        GrantedScopes: string;
        isSignedIn: boolean;
        UserId: string;
    }
    class GoogleData {
        GoogleUser: gapi.auth2.GoogleUser;
        BasicProfile: googleBasicProfile;
        Data: googleAuthData;
    }
    export class GoogleProvider {
        private apiKey;
        private clientId;
        private scope?;
        Data: GoogleData;
        Error: any;
        private constructor();
        static _cache: Map<string, GoogleProvider>;
        static GetProvider(apiKey: string, clientId: string, scope?: string): GoogleProvider;
        InitEngine(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        InitApp(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        IsAuthenticated(): Promise<boolean>;
        Login(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
        LoadProfile(cancellationToken?: Tasks.CancellationToken): Promise<boolean>;
    }
    export {};
}
declare namespace Calysto.Page.Google {
    class AnalyticsService {
        private trackingId;
        private gtag;
        constructor(trackingId: string);
        private EnsureEngineLoaded;
        /**
         * Hit ajax page view.
         * @param pagePath
         *		eg. /new-page.html
         *		if not set, will hit current page
         */
        HitPageView(pagePath?: string): this;
    }
}
declare namespace Calysto.Page.Microsoft {
    class ClarityProvider {
        private clarityId;
        constructor(clarityId: string);
        private EnsureEngineLoaded;
        Start(): void;
    }
}
declare namespace Calysto.Page.Preloader {
    function Enable(delayMs?: number): void;
    function Disable(): void;
}
declare namespace Calysto.Page.Diagnostic {
    function ElmahLog(errMsg: string, errDetails: string): void;
    function ErrorHandler(ev: ErrorEvent | PromiseRejectionEvent): void;
}
declare namespace Calysto.AjaxHistory {
    type StateArrItemType = {
        functionName?: string;
        selector?: string;
        html?: string;
    };
    /**
     * Will save current state, then modify with new values and save new state, so the back-forward will work.
     * @param stateArray [{selector:.., html:..}, {selector:.., html:..}...]
     */
    function PushState(stateArray: StateArrItemType[]): void;
}
declare namespace Calysto {
    type TDataObject = {
        senderUID: string;
        destinationUID: string;
        funcName: string;
        argument: any;
        isCallback?: boolean;
        callbackFuncName?: string;
    };
    interface IPostMessageEvent extends MessageEvent {
        data: string;
        dataObject: TDataObject;
    }
    export class PostMessage {
        /**
         * PostMessage instance unique id
         * @param {string} UID?
         */
        private _uniqueUID;
        private _listenersArr;
        private _funcBag;
        constructor(UID?: string);
        private AddDistinctListener;
        private EncapsulateFunc;
        /**
         * Register function in postmessage instance.
         * @param {string} funcName Name of the function.
         * @param {(sentValue} funcRef Acctual function which will receive and process the sentValue. Function returns TReturn at the end.
         * @param {function} ev
         * @returns
         */
        RegisterMethod<TSend, TReturn>(funcName: string, funcRef: (sentValue: TSend, ev: IPostMessageEvent) => TReturn): this;
        InvokeMethod<TSend, TReturn>(destinationUID: string, funcName: string, sendValue: TSend, callbackFunc?: (returnedValue: TReturn, ev: IPostMessageEvent) => void): this;
        Echo(destinationUID: string, msg: string, callbackFunc: (returnedValue: string, ev: IPostMessageEvent) => void): this;
        private HandleMessageEvent;
        static FindIframe(arg: MessageEvent | Window): HTMLIFrameElement | null;
    }
    export {};
}
declare namespace Calysto.Forms {
    type SerializedElementType = {
        Element: HTMLInputElement;
        Name: string;
        /** value may be any type, since it may be value returned from getter fn */
        Value: string | string[] | any;
        /** if it is not null or undefined or NaN, empty string is considred as value */
        HasValue: boolean;
    };
    export function SerializeContainer(containerSelector: string | HTMLElement): SerializedElementType[];
    /**
     * Reset all values do defaults. Exclude disabled or readOnly elements.
     * @param {string | HTMLElement} containerSelector
     */
    export function ResetForm(containerSelector: string | HTMLElement): void;
    /**
     * Form-serialize containerSelector into dictionary. Serializes inputs with 'name' attribute. Returns dictionary: {name1: value1, name2: value2, ...}<br/>
        If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
        If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} trimStrings?
     * @param {TResult} refOutDataObj?
     * @returns
     */
    export function FormSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult;
    /**
     * Bind data from dataObj dictionay to any element (not just input) with 'name' or 'id' attribute named as dataObj properties<br/>
        If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
        If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
        If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
     * @param {any} dataObj
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} alwaysSet?
     */
    export function FormDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean): void;
    /**
     * Form-serialize values into dictionary.
     * Ignores null or empty values.
     * Serializes inputs with 'name' attribute. Name may have nested path: prop1.prop2.prop3. It builds nested js objects.
        If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
        If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} trimStrings?
     * @param {TResult} refOutDataObj?
     * @returns
     */
    export function MvcSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult;
    /**
     * Bind data from dataObj to any element (not just inputs) with 'name' or 'id' attributes named as dataObj properties or asp.net style names with pp$aa$propName<br/>
        If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
        If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
        If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
     * @param {any} dataObj
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} alwaysSet?
     */
    export function MvcDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean): void;
    /**
     * Serialize values from input elements with 'calysto-id' attribute into dictionary by creating properties named as calysto-id attribute values.<br/>
        Property names may by compound path, eg. prop1.prop2.prop3, it creates nested object using Calysto.DataBinder.SetValue(...).<br/>
        If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
        If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} trimStrings?
     * @param {TResult} refOutDataObj?
     * @returns
     */
    export function CalystoSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult;
    /**
     * Bind data from dataObj to any element with 'calysto-id' attribute named as dataObj properties.<br/>
        Property names may by compound path, eg. prop1.prop2.prop2, value is read using Calysto.DataBinder.TryGetValue(...).<br/>
        If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
        If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
        If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
     * @param {any} dataObj
     * @param {string | HTMLElement} containerSelector
     * @param {boolean} alwaysSet?
     */
    export function CalystoDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean): void;
    export function CalystoSerialize2<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult;
    export function CalystoDeserialize2(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean): void;
    export function ToMvcModelState<TModel>(containerSelector: string | HTMLElement): Web.UI.Direct.CalystoMvcModelState<TModel>;
    export {};
}
declare namespace Calysto {
    class SelectorReader {
        private selector;
        constructor(selector: string);
        private currPosition;
        Peek(forwardBy?: number): string;
        Pop(): string;
        PopMatch(regex: RegExp, origin?: number): RegExpMatchArray | null;
    }
}
declare namespace Calysto {
    type CallbackDelegate<TSender> = (sender: TSender, ev: Event) => void | boolean | undefined;
    type MouseCallbackDelegate<TSender> = (sender: TSender, ev: MouseEvent) => void | boolean | undefined;
    type KeyboardCallbackDelegate<TSender> = (sender: TSender, ev: KeyboardEvent) => void | boolean | undefined;
    export class PoolingState<TItem> {
        private query;
        private intervalID;
        constructor(query: DomQuery<TItem>, intervalID: number);
        /**Abort pooling state for changes */
        Abort(): this;
        AsDomQuery(): DomQuery<TItem>;
    }
    export class DomQuery<TItem> extends CalystoEnumerable<TItem> {
        constructor(getEnumerator: () => CalystoEnumerator<TItem>);
        ForEach(action: (item: TItem, index: number) => void): DomQuery<TItem>;
        Skip(count: number): DomQuery<TItem>;
        Take(count: number): DomQuery<TItem>;
        SkipWhile(predicate: (item: TItem, index: number) => boolean): DomQuery<TItem>;
        Reverse(): DomQuery<TItem>;
        Where(predicate: (item: TItem, index: number) => boolean): DomQuery<TItem>;
        Select<TNew>(selector: (item: TItem, index: number) => TNew): DomQuery<TNew>;
        Cast<TNew>(): DomQuery<TNew>;
        SelectMany<TNew>(selector?: (item: TItem) => TNew[] | CalystoEnumerable<TNew>): DomQuery<TNew>;
        Distinct<TKey>(keySelector?: (item: TItem) => TKey): DomQuery<TItem>;
        private selectFilteredSingle;
        /**
            Operates on current document.all and select elements by calystoSelector as document.all.Query(args).
         * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, span, a, ...
ID: #idvalue...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
         */
        Query<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        /**
         * Filter current items by calystoSelector.
         * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, span, a, ...
ID: #idvalue...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
         */
        private QueryWorker;
        /**
         * Parent nodes only.
         * @param calystoSelector lambda or css calystoSelector
         */
        ParentNodes<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        /**
         * All ancestors.
         * @param calystoSelector lambda or css calystoSelector
         */
        AncestorNodes<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        /**
         * Child nodes only,
         * @param calystoSelector lambda or css calystoSelector
         */
        ChildNodes<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        private getDescendants;
        /**
         * Descendant nodes.
         * @param calystoSelector lambda or css calystoSelector
         */
        DescendantNodes<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        NextSiblings<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        PreviousSiblings<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>;
        /**
         * Case non-sensitive tagName.
         * @param tagName
         */
        WhereTagName(tagName: string): DomQuery<TItem>;
        /**
         * Filter items by attribute value.
         * @param name case non-sensitive
         * @param predicate
         */
        WhereAttribute(name: string, predicate: (attrValue: string) => boolean): DomQuery<TItem>;
        /**
         * Filter items by attribute.
         * @param name attribute name
         * @param hasIt OPTIONAL. If not set, default is true.
         */
        WhereHasAttribute(name: string, hasIt?: boolean): DomQuery<TItem>;
        /**
         * Filter items by style value.
         * @param name case sensitive, valid css style name, camel case or with
         * @param predicate
         */
        WhereStyle(name: string, predicate: (styleValue: number) => boolean): DomQuery<TItem>;
        /**
         * Where attribute obj.id='id', always case-sensitive.
         * @param idvalue Case sensitive dom element id.
         */
        WhereId(idvalue: string): DomQuery<TItem>;
        /**
         * Where contains cssClass, always case-sensitive.
         * @param cssClass Case sensitive css class name.
         * @param hasIt OPTIONAL. If not set, default is true.
         */
        WhereHasClass(cssClass: string, hasIt?: boolean): DomQuery<TItem>;
        /**
         * Select NumericValue or StyleValue, which one is available first. Returns new Calysto.List with values.
         * @param name style property name
         */
        SelectStyle(name: string): DomQuery<string | number>;
        /**
         * Select NumericValue or StyleValue, which one is available first.
         * Returns TMap[] with objects who's properties are array names: [{name1:value1, name2:value2}, {name1: value, name2: value}, ...].
         * @param mapObj Object with names to be selected: {"width": null, "height": null}
         */
        SelectStyleMap<TMap>(mapObj: TMap): DomQuery<TMap>;
        SelectDimensionsMap(): DomQuery<{
            absoluteTop: number;
            absoluteLeft: number;
            position: string;
            top: number;
            right: number;
            bottom: number;
            left: number;
            width: number;
            height: number;
            minWidth: number;
            minHeight: number;
            maxWidth: number;
            maxHeight: number;
            clientLeft: number;
            clientTop: number;
            clientWidth: number;
            clientHeight: number;
            offsetLeft: number;
            offsetTop: number;
            offsetWidth: number;
            offsetHeight: number;
            scrollLeft: number;
            scrollTop: number;
            scrollWidth: number;
            scrollHeight: number;
            paddingTop: number;
            paddingRight: number;
            paddingBottom: number;
            paddingLeft: number;
            marginTop: number;
            marginRight: number;
            marginBottom: number;
            marginLeft: number;
            borderTop: number;
            borderRight: number;
            borderBottom: number;
            borderLeft: number;
        }>;
        /**
         * Set elements style.
         * @param styleMap {marginTop: 10, "margin-left": "22%"}
         */
        ApplyStyleMap(styleMap: Object): DomQuery<TItem>;
        /**
         * Set style value. If value is eg. 20%, it will get current value first, than set 20% of current value.
         * @param nameOrCssText cssText or style name or style map {height:10, width:20}, case sensitive style name or camelCase name
         * @param value if cssText used, value is empty, else style value
         */
        ApplyStyle(nameOrCssText: string | Object, value?: string | number): DomQuery<TItem>;
        /**
         * Set elements offset dimensions by recalculating and setting style values.
         * Size may be set only if element is visible.
         * @param offsetWidth if value not int, won't be set
         * @param offsetHeight if value not int, won't be set
         */
        SetOffsetSize(offsetWidth: number | null, offsetHeight: number | null): DomQuery<TItem>;
        /**
         * Fit each element into it's parent. Useful for elements with padding set so style.width can not be set to 100% to fit into parent.
         * @param fitWidth
         * @param fitHeight
         */
        FitIntoParent(fitWidth: boolean, fitHeight: boolean): DomQuery<TItem>;
        /**
         * Select attribute value and return new Calysto.List with values.
         * @param name
         */
        SelectAttribute(name: string): DomQuery<string>;
        /**
         * Return TMap[] (TMap for each element) with objects who's properties are names from array:
         * [{name1:value1, name2:value2}, {name1: value, name2: value}, ...]
         * @param mapObj object with names to be selected: {"width": null, "height": null}
         */
        SelectAttributeMap<TMap>(mapObj: TMap): DomQuery<TMap>;
        /**
         * Return dictionary {[key:attrName]: attrValue} for each element.
         * */
        SelectAttributesAll(): DomQuery<{
            [key: string]: string;
        }>;
        /**
         * Set attribute value.
         * @param name name is case non-sensitive
         * @param value
         * @param add OPTIONAL. If not set, default is true.
         */
        SetAttribute(name: string, value: any, add?: boolean): DomQuery<TItem>;
        /**
         * Remove attribute by name.
         * @param name attribute name
         */
        RemoveAttribute(name: string): DomQuery<TItem>;
        /**
         * Convert value to string and set as innerHTML to every element in collection.
         * @param html
         */
        SetInnerHtml(html?: string | null | undefined): DomQuery<TItem>;
        /**
         * If target element supports "value", will add content as value, else, will invoke ReplaceChildren
         * @param content
         */
        SetValueOrInnerHtml(content?: any): DomQuery<TItem>;
        SetProperty(property: string, value: string | any): DomQuery<TItem>;
        SetChecked(value: boolean): DomQuery<TItem>;
        /**
         * Convert value to string and append to innerHTML of every element in collection.
         * @param html
         */
        AppendInnerHtml(html: string): DomQuery<TItem>;
        /**
         * Convert value to string and append to innerHTML of every element in collection.
         * @param html
         */
        PrependInnerHtml(html: string): DomQuery<TItem>;
        /**
         * Search for 'script' elements and mark them as executed.
         * So will not execute it again from ExecuteScriptNodes().
        */
        MarkScriptsExecuted(): DomQuery<TItem>;
        /**
         * Search for 'script' elements, execute it's content and mark them as executed.
         * So will not execute them next time when ExecuteScriptNode() invoked.
         * @param alwaysExecute
         */
        ExecuteScriptNodes(alwaysExecute?: boolean): DomQuery<TItem>;
        /** Select innerHTML value from each element. */
        SelectInnerHtml(): DomQuery<string>;
        /** Select innerHTML value from each element. */
        SelectInnerText(): DomQuery<string>;
        WhereText(textToSearch: string, ignoreCase: boolean): DomQuery<TItem>;
        /**
         * Add css class to classes collection.
         * @param cssClass
         * @param add OPTIONAL. If not set, default is true.
         */
        AddClass(cssClass: string, add?: boolean): DomQuery<TItem>;
        /**
         * Remove css class from classes collection.
         * @param cssClass
         */
        RemoveClass(cssClass: string): DomQuery<TItem>;
        /**
         * Set css class value, removing previous values.
         * @param cssClass
         */
        SetClass(cssClass: string): DomQuery<TItem>;
        /**
         * If doesn't exist, add class, else remove it.
         * @param cssClass
         */
        ToggleClass(cssClass: string): DomQuery<TItem>;
        /**
         * Select class names.
        */
        SelectClassNames(): DomQuery<string>;
        /**
         * Test if current element is visible in DOM, using style.display and offsetHeight and offsetWidht and style.visibility.
         * @param isVisible OPTIONAL, default is true
         */
        WhereVisible(isVisible?: boolean): DomQuery<TItem>;
        /**
         * Test if element and ancestors are visible in DOM, up to documentElement node, using style.display and offsetHeight and offsetWidht and style.visibility.
         * @param isVisible OPTIONAL, default is true
         */
        WhereDomTreeVisible(isVisible?: boolean): DomQuery<TItem>;
        /**
         * Test if element is visible in DOM and in viewport (on screen) only part
         * @param isVisible
         */
        WhereInViewPort(isVisible?: boolean, onlyPart?: boolean): DomQuery<TItem>;
        /**
         * Test if "disabled" attribute exists.
         * @param isEnabled OPTIONAL. If not set, default is true.
         */
        WhereEnabled(isEnabled?: boolean): DomQuery<TItem>;
        /**
         * Bind event handler to current items.
         * @param eventFullNameOrArr
         *	- event name with class name, ex: click.one1.two2
         *	- event name or array of event names without 'on' on start (click, mouserover, mousemove,...)
         *	- may include namespace for simple removal as [eventType].[namespace]: click.my_one, click.mynode.divone
         * @param callbackFunc
         *	function(sender, event){ }, if not bound to different context, inside of function this == sender
         * @param useCapture
         *	if true, use capture, trigger event before all other
         * @param triggCountMax
         *	number of how many times to trigger, after that events are ignored
         */
        On(eventFullNameOrArr: string | string[], callbackFunc: CallbackDelegate<TItem>, useCapture?: boolean, triggCountMax?: number): DomQuery<TItem>;
        /**
         * Callback after event is attached. eventDef may be used to remove event at later time.
         * @param fn
         */
        readonly OnEventAttached: IFuncMulticastDelegate<(eventDef: ICalystoEventDefinition) => void, this>;
        /**
         * Remove event by eventFullName (event type.namespace). Can remove previously added with .On(...)
         * @param eventFullName
         * - full name including namespace, or namespace only, or name only
         * - full event name to be removed, without on: (click, change,...)
         * - may include namespace for simple removal as [eventType].[namespace]: click.my_one, click.mynode.divone
         */
        RemoveEvent(eventFullName: any): DomQuery<TItem>;
        /**
         * Dispatch event or event type on element el.
         * @param event
         */
        DispatchEvent(event: Event): DomQuery<TItem>;
        /**
         * Hover event on mouse enter or mouse leave an element.
         * @param onOver function(sender, event){...}
         * @param onOut function(sender, event){...}
         */
        OnHover(onOver: CallbackDelegate<TItem>, onOut?: CallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnChange(callbackFunc: CallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         * Monitor for changes in value or checked property in regular intervals.
         * Default pooling interval = 100 ms.
         * @param callbackFunc
         * @param intervalMs default = 100 ms
         */
        OnChangePooling(callbackFunc: CallbackDelegate<TItem>, intervalMs?: number): PoolingState<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnInput(callbackFunc: CallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnClick(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnDblClick(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnMouseUp(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnMouseDown(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnMouseOver(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnMouseOut(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnLeftMouseDown(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnRightMouseDown(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnMouseMove(callbackFunc: MouseCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnFocus(callbackFunc: CallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnBlur(callbackFunc: CallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         * Has NO ev.charCode, only ev.keyCode, triggers on any key press (eg. shift, ctrl, F1...)
         * @param callbackFunc function(sender, event){...}
         */
        OnKeyDown(callbackFunc: KeyboardCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         * Has NO ev.charCode, only ev.keyCode, triggers on any key press (eg. shift, ctrl, F1...)
         * @param callbackFunc function(sender, event){...}
         */
        OnKeyUp(callbackFunc: KeyboardCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         * has ev.charCode and ev.keyCode, triggers on chars only, doesn't trigger with special keys eg. shift, ctrl, F1
         * @param callbackFunc function(sender, event){...}
         */
        OnKeyPress(callbackFunc: KeyboardCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnEnter(callbackFunc: KeyboardCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         *
         * @param callbackFunc function(sender, event){...}
         */
        OnEscKey(callbackFunc: KeyboardCallbackDelegate<TItem>): DomQuery<TItem>;
        /**
         * Deep clone current nodes and return cloned nodes only.
         * @returns
         */
        CloneNodes(): DomQuery<TItem>;
        /**
         * Disconnect nodes from DOM.
         * @returns
         */
        RemoveFromDom(): DomQuery<TItem>;
        /**
         * Replace each node with new html or element. if content is null, remove node from dom. Returnes new (replacement) nodes.
         * @param {any[]} ...content
         * @returns
         */
        ReplaceWith(...content: any[]): DomQuery<HTMLElement>;
        /**
         * Replace each current collection node's children with content. if content is null, remove children only. Returns current collection.
         * @param {any[]} ...content
         * @returns
         */
        ReplaceChildren(...content: any[]): this;
        RemoveChildren(): this;
        /**
         * Add content as last child to each node in current collection. Returns current collection.
         * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
         * @returns
         */
        AddChildren(...content: any[]): this;
        /**
         * Insert content as first child to each node in current collection. Returns current collection.
         * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
         * @returns
         */
        InsertChildren(...content: any[]): this;
        /**
         * Insert content before every node in current collection. Returns current collection.
         * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
         * @returns
         */
        InsertBefore(...content: any[]): this;
        /**
         * Insert content after every node in current collection. Returns current collection.
         * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
         * @returns
         */
        InsertAfter(...content: any[]): this;
        /**
         * Insert current collection nodes as first children into nodes specified by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
         * @param {string | HTMLElement} calystoSelector
         * @returns
         */
        InsertAsChildrenTo(calystoSelector: string | HTMLElement): DomQuery<HTMLElement>;
        /**
         * Add current collection as last children into nodes specified by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
         * @param {string | HTMLElement} calystoSelector
         * @returns
         */
        AddAsChildrenTo(calystoSelector: string | HTMLElement): DomQuery<HTMLElement>;
        /**
         * Insert current collection before nodes selected by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
         * @param {string | HTMLElement} calystoSelector
         * @returns
         */
        InsertBeforeTo(calystoSelector: string | HTMLElement): DomQuery<HTMLElement>;
        /**
         * Insert current collection after nodes selected by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
         * @param {string | HTMLElement} calystoSelector
         * @returns
         */
        InsertAfterTo(calystoSelector: string | HTMLElement): DomQuery<HTMLElement>;
        /**
         * Sleep execution with setTimeout. Can be used for branching. When expired, execute onExpired.call(this, this). "this" is sent both as parameter and as context.
         * @param {number} sleepMs
         * @param {(sender} onExpired function to execute onExpired.call(this, this)
         * @returns
         */
        Sleep(sleepMs: number, onExpired: (sender: DomQuery<TItem>) => void): this;
        /**
         * Export current elements to animator. Animate from current style settings to finalMap settings.
         * @param finalMap final values to animate to, eg. {height:40, opacity:25, marginTop: 54}
         */
        ToAnimator<TMap>(finalMap: TMap): Animator;
        /**
         * Add onselectstart handler which returns false.
         * @param isSelectable OPTIONAL. If not set, default is true.
         */
        SetSelectable(isSelectable?: boolean): DomQuery<TItem>;
        /**
         * Set attribute disabled=disabled and disable onclick handler. LIMITATION: "disabled" has to be set on all descendants.
         * @param isEnabled OPTIONAL. If not set, default is true.
         */
        SetEnabled(isEnabled?: boolean): DomQuery<TItem>;
        /**
         * If isVisible == true: set display="".
         * If isVisible == false: set style display="none".
         * @param isVisible
         */
        SetVisible(isVisible?: boolean): DomQuery<TItem>;
        /**
         *
         * @param isReadonly default: true
         */
        SetReadOnly(isReadonly?: boolean): DomQuery<TItem>;
        /**
         * Set opacity
         * @param value 0.0 - 1.0 (full visibility = 1.0)
         */
        SetOpacity(value: number): DomQuery<TItem>;
        /**
         *
         * @param clipValue already parsed into object, or string: "margins(100% 0 0 0)" or "rect:(10px 100px 50px 53px)
         */
        SetClip(clipValue: Object | string): DomQuery<TItem>;
        /**
         * Single line transition.
         *
         * @param propertyName
         * "none" to remove transition (optional, default: all) Specifies the name of the CSS property the transition effect is for. Css default is all.
         *
         * @param durationMs
         * (optional, default: 400ms) Specifies how many seconds or milliseconds the transition effect takes to complete. Css default is 0
         *
         * @param func (optional, default: linear)
         * - linear	Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
         * - ease	Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1))
         * - ease-in	Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1))
         * - ease-out	Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1))
         * - ease-in-out	Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
         * - cubic-bezier(n,n,n,n)	Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
         *
         * @param delayMs
         */
        SetTransition(propertyName?: string, durationMs?: number, func?: string, delayMs?: number): this;
        /**
         * Remove any previous transform and apply new.
         * - angle must have deg: eg. 45deg
         * - x,y,z values must have px units
         * - scale has no units
         *
         * @param transformFunc
         * - none
         * - matrix(n,n,n,n,n,n) 2D transform
         * - matrix3d(n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n) 3D transform
         * - translate(x,y)
         * - translate3d(x,y,z)
         * - translateX(x)
         * - translateY(y)
         * - translateZ(z)
         * - scale(x,y)
         * - scale3d(x,y,z)
         * - scaleX(x)
         * - scaleY(y)
         * - scaleZ(z)
         * - rotate(angle)
         * - rotate3d(x,y,z,angle)
         * - rotateX(angle)
         * - rotateY(angle)
         * - rotateZ(angle)
         * - skew(x-angle,y-angle)
         * - skewX(angle)
         * - skewY(angle)
         * - perspective(n)
         */
        SetTransform(transformFunc: string): this;
        /**
         * Get current transform and apply modification to existing transform only.
         * - angle must have deg: eg. 45deg
         * - x,y,z values must have px units
         * - scale has no units
         *
         * @param transformFunc
         * - none
         * - matrix(n,n,n,n,n,n) 2D transform
         * - matrix3d(n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n) 3D transform
         * - translate(x,y)
         * - translate3d(x,y,z)
         * - translateX(x)
         * - translateY(y)
         * - translateZ(z)
         * - scale(x,y)
         * - scale3d(x,y,z)
         * - scaleX(x)
         * - scaleY(y)
         * - scaleZ(z)
         * - rotate(angle)
         * - rotate3d(x,y,z,angle)
         * - rotateX(angle)
         * - rotateY(angle)
         * - rotateZ(angle)
         * - skew(x-angle,y-angle)
         * - skewX(angle)
         * - skewY(angle)
         * - perspective(n)
         */
        ApplyTransform(transformFunc: string): DomQuery<TItem>;
        /**Select transform value of current elements and return new Calysto.List with string values. */
        SelectTransform(): DomQuery<string>;
        SetLinearGradient(degrees: any, color0: any, color1: any, color3: any, etc: any): DomQuery<TItem>;
        /**
         * Returns Animator instance. item.Start() has to be invoked to start animation.
         * @param alignToTop default: false, will align to bottom
         */
        ToAnimatorScrollIntoView(alignToTop?: boolean): Animator;
        static FromArray<TElement>(arr: TElement[]): DomQuery<TElement>;
        /**
            Operates on current document.all and select elements by calystoSelector as document.all.Query(args)
         * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, div, span, a, ...
ID: #idvalue, ...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
         */
        static FromSelector<TElement extends HTMLElement>(calystoSelector: TElement | string | Node | TElement[] | any[] | CalystoEnumerable<any>): DomQuery<TElement>;
        /**
         * Returns string [name=pathExpression]
         * @param pathExpression
         */
        static FromPathExpression<TModel>(pathExpression: (m: TModel) => any): DomQuery<HTMLElement>;
        /**
         * Creates source from xmlString.
         * @param xmlString
         */
        static FromXml(xmlString: string): DomQuery<HTMLElement>;
        /**
         * Creates source from html string.
         * @param htmlString
         */
        static FromHtml(htmlString: string): DomQuery<HTMLElement>;
        static CreateElement<TItem extends HTMLElement>(tagName: string): DomQuery<TItem>;
    }
    export {};
}
declare var $$calysto: typeof Calysto.DomQuery.FromSelector;
declare namespace Calysto.Colorspace {
    var NamedColors: {
        aliceblue: string;
        antiquewhite: string;
        aqua: string;
        aquamarine: string;
        azure: string;
        beige: string;
        bisque: string;
        black: string;
        blanchedalmond: string;
        blue: string;
        blueviolet: string;
        brown: string;
        burlywood: string;
        cadetblue: string;
        chartreuse: string;
        chocolate: string;
        coral: string;
        cornflowerblue: string;
        cornsilk: string;
        crimson: string;
        cyan: string;
        darkblue: string;
        darkcyan: string;
        darkgoldenrod: string;
        darkgray: string;
        darkgrey: string;
        darkgreen: string;
        darkkhaki: string;
        darkmagenta: string;
        darkolivegreen: string;
        darkorange: string;
        darkorchid: string;
        darkred: string;
        darksalmon: string;
        darkseagreen: string;
        darkslateblue: string;
        darkslategray: string;
        darkslategrey: string;
        darkturquoise: string;
        darkviolet: string;
        deeppink: string;
        deepskyblue: string;
        dimgray: string;
        dimgrey: string;
        dodgerblue: string;
        firebrick: string;
        floralwhite: string;
        forestgreen: string;
        fuchsia: string;
        gainsboro: string;
        ghostwhite: string;
        gold: string;
        goldenrod: string;
        gray: string;
        grey: string;
        green: string;
        greenyellow: string;
        honeydew: string;
        hotpink: string;
        indianred: string;
        indigo: string;
        ivory: string;
        khaki: string;
        lavender: string;
        lavenderblush: string;
        lawngreen: string;
        lemonchiffon: string;
        lightblue: string;
        lightcoral: string;
        lightcyan: string;
        lightgoldenrodyellow: string;
        lightgray: string;
        lightgrey: string;
        lightgreen: string;
        lightpink: string;
        lightsalmon: string;
        lightseagreen: string;
        lightskyblue: string;
        lightslategray: string;
        lightslategrey: string;
        lightsteelblue: string;
        lightyellow: string;
        lime: string;
        limegreen: string;
        linen: string;
        magenta: string;
        maroon: string;
        mediumaquamarine: string;
        mediumblue: string;
        mediumorchid: string;
        mediumpurple: string;
        mediumseagreen: string;
        mediumslateblue: string;
        mediumspringgreen: string;
        mediumturquoise: string;
        mediumvioletred: string;
        midnightblue: string;
        mintcream: string;
        mistyrose: string;
        moccasin: string;
        navajowhite: string;
        navy: string;
        oldlace: string;
        olive: string;
        olivedrab: string;
        orange: string;
        orangered: string;
        orchid: string;
        palegoldenrod: string;
        palegreen: string;
        paleturquoise: string;
        palevioletred: string;
        papayawhip: string;
        peachpuff: string;
        peru: string;
        pink: string;
        plum: string;
        powderblue: string;
        purple: string;
        red: string;
        rosybrown: string;
        royalblue: string;
        saddlebrown: string;
        salmon: string;
        sandybrown: string;
        seagreen: string;
        seashell: string;
        sienna: string;
        silver: string;
        skyblue: string;
        slateblue: string;
        slategray: string;
        slategrey: string;
        snow: string;
        springgreen: string;
        steelblue: string;
        tan: string;
        teal: string;
        thistle: string;
        tomato: string;
        turquoise: string;
        violet: string;
        wheat: string;
        white: string;
        whitesmoke: string;
        yellow: string;
        yellowgreen: string;
    };
    namespace ColorConverter {
        function ParseToRGB(colorStr: string): RGB;
    }
    class HSL {
        /**int, 0...360*/
        h: number;
        /**double, 0...1*/
        s: number;
        /**double, 0...1*/
        l: number;
        /**double, 0...1*/
        a: number;
        constructor(hue: any, saturation: any, luminance: any, alpha: any);
        static Parse(colorStr: any): HSL;
        Clone(): HSL;
        Set(fn: (rgb: HSL) => void): this;
        ToHslString(): string;
        ToRGB(): RGB;
    }
    class RGB {
        /**int, 0...255*/
        r: number;
        /**int, 0...255*/
        g: number;
        /**int, 0...255*/
        b: number;
        /**decimal, 0...1*/
        a: number;
        constructor(r: any, g: any, b: any, alpha: any);
        static Parse(colorStr: any): RGB;
        Clone(): RGB;
        Set(fn: (rgb: RGB) => void): this;
        ToRgbString(): string;
        ToHexString(): string;
        ToHSL(): HSL;
        ToCMYK(): CMYK;
    }
    class CMYK {
        /**int, 0...100*/
        c: number;
        /**int, 0...100*/
        m: number;
        /**int, 0...100*/
        y: number;
        /**int, 0...100*/
        k: number;
        constructor(c: any, m: any, y: any, k: any);
        ToRGB(): RGB;
    }
}
declare namespace Calysto {
    namespace EasingHelper {
        const easings: {
            linear: (p: any, n: any, firstNum: any, diff: any) => any;
            swing: (p: any, n: any, firstNum: any, diff: any) => any;
            easeInQuad: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutQuad: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutQuad: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInCubic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutCubic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutCubic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInQuart: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutQuart: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutQuart: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInQuint: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutQuint: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutQuint: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInSine: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutSine: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutSine: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInExpo: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutExpo: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutExpo: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInCirc: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutCirc: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutCirc: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInElastic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutElastic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutElastic: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInBack: (x: any, t: any, b: any, c: any, d: any, s: any) => any;
            easeOutBack: (x: any, t: any, b: any, c: any, d: any, s: any) => any;
            easeInOutBack: (x: any, t: any, b: any, c: any, d: any, s: any) => any;
            easeInBounce: (x: any, t: any, b: any, c: any, d: any) => any;
            easeOutBounce: (x: any, t: any, b: any, c: any, d: any) => any;
            easeInOutBounce: (x: any, t: any, b: any, c: any, d: any) => any;
        };
        export type TEasing = keyof typeof easings;
        /**
         *
         * @param {keyof typeof easings} easingName
         * @param {number} startValue
         * @param {number} finalValue
         * @param {number} currentTimeFraction 0-1
         * @returns
         */
        export function InvokeEasing(easingName: TEasing, startValue: number, finalValue: number, currentTimeFraction: number): any;
        export {};
    }
    class AnimItem {
        onTick?: (sender: Animator, currentValue: number) => void;
        element: HTMLElement;
        elStyleName: string;
        elFinalValue: number | string;
        clipStart: Utility.Dom.ClipDimension;
        clipCurrent: Utility.Dom.ClipDimension;
        clipFinal: Utility.Dom.ClipDimension;
        rgbStart: Colorspace.RGB;
        rgbCurrent: Colorspace.RGB;
        rgbFinal: Colorspace.RGB;
        transformStart: number[];
        transformCurrent: number[];
        transformFinal: number[];
        transformFormat: string;
        numStart: number;
        numFinal: number;
        numCurrent: number;
        isNumValue: boolean;
        elUnits: string;
    }
    export class Animator {
        static InvokeEasing: typeof EasingHelper.InvokeEasing;
        static RequestAnimationFrame(onAcquired: () => void): any;
        private items;
        private durationMs;
        private onComplete;
        private onStart;
        private onProgress;
        private onAbort;
        private easing;
        private state;
        constructor();
        /**
         * Returns all items, both DOM and non-dom.
         */
        Items(): AnimItem[];
        /**
         * Returns distinct DOM elements list.
         */
        ToList(): List<HTMLElement>;
        /**
         * Returns distinct DOM elements DomQuery.
         */
        AsDomQuery(): DomQuery<HTMLElement>;
        /**
         * Push DOM element with final value setting. Animation will run from current state to final setting.
         * @param element
         * @param styleName
         * @param finalValue
         * can be exact value or eg. "+=10", "-=50", "*=34"
         * @param onTick
         * optional, Function, eg. function(animator, currentValue){...}, this is animator instance
         */
        AddElement(element: HTMLElement, styleName: string, finalValue: number | string, onTick?: (sender: Animator, currentValue: number) => void): this;
        AddValue(startValue: number, finalValue: number, onTick?: (sender: Animator, currentValue: number) => void): this;
        Clear(): this;
        Duration(durationMs?: number): this;
        OnProgress(callback: (sender: Animator, percent: number) => void): this;
        OnStart(callback: (sender: Animator) => void): this;
        OnComplete(callback: (sender: Animator) => void): this;
        OnAbort(callback: (sender: Animator) => void): this;
        Easing(easingType: EasingHelper.TEasing): this;
        private initializeFirstRun;
        private GetCurrent;
        private animateStartTicks;
        private TimerTick;
        IsRunning(): boolean;
        private _delayTimeoutId;
        Start(delayMs?: number): this;
        Abort(): this;
        /** Start and wait async until animation is complete */
        StartAsync(delayMs?: number): Promise<Animator>;
    }
    export {};
}
declare namespace Calysto.Preloaders {
    function Squares(color?: string, backColor?: string, rotateCCV?: boolean): string;
    function Snake(color?: string, rotateCCV?: boolean): string;
    function BallsRing(color?: string, rotateCCV?: boolean): string;
    function MsRing(color?: string, backColor?: string, rotateCCV?: boolean): string;
    function TwoArrows(color?: string): string;
    function Flower(color?: string, rotateCCV?: boolean): string;
    function ThreeArcs(color?: string, rotateCCV?: boolean): string;
    function ThreeDots(color?: string): string;
    function BallTriangle(color?: string): string;
    function Bars(color?: string): string;
    function Oval(color?: string, backColor?: string, rotateCCV?: boolean): string;
    function Messenger(color?: any): string;
    function RotatingBalls(color?: any): string;
}
declare namespace Calysto {
    class DataTable {
        Columns: string[];
        Rows: any[][];
        TotalCount: number;
        TableName: string;
        constructor();
        ToObjectsArray(): any[];
        Clone(): DataTable;
        private fromObjectsArray;
        private fromDataTable;
        static CreateFrom(data: any): DataTable;
    }
}
declare namespace Calysto {
    class List<TElement> extends CalystoEnumerable<TElement> implements IInnerArray<TElement> {
        private readonly array;
        get InnerArray(): TElement[];
        constructor(source?: CalystoEnumerable<TElement> | TElement[]);
        Add(value: TElement): this;
        AddRange(arr: TElement[]): this;
        Count(): number;
        Any(): boolean;
        Insert(index: number, value: TElement): this;
        ElementAt(index: number, defaultValue?: TElement): TElement | undefined;
        Remove(value: TElement): this;
        RemoveAt(index: number): this;
        /**
         * in-place splice
         * @param {number} index
         * @param {number} count?
         * @returns
         */
        RemoveRange(index: number, count?: number): this;
        /**
         * in place reverse
         * @returns
         */
        Reverse(): this;
        IndexOf(value: TElement): number;
        Contains(value: TElement): boolean;
        Clear(): this;
        /**
         * Returns new copy of inner array
         * @returns
         */
        ToArray(): TElement[];
        /** create new instance of List from sliced inner array. */
        ToList(): List<TElement>;
        ToStringJoined(separator?: string): string;
        ForEach(action: (item: TElement, index: number) => void): this;
        FirstOrDefault(defaultValue?: TElement): TElement;
        First(): TElement;
        LastOrDefault(defaultValue?: TElement): TElement;
        Last(): TElement;
    }
}
declare namespace Calysto.Utility {
    class StringCompressor {
        private CompressImpl;
        Compress(text: string, passesMax?: number): string;
        Decompress(json: string): string;
    }
}
declare namespace Calysto.Security.Cryptography {
    class SimpleEncryptor {
        /**
         * Simple encrypter. Creates remaping table 256 bytes to 256 bytes.
         * @param password
         */
        constructor(password: string);
        private _dicEncryption;
        private _dicDecryption;
        Encrypt(rawData: string | number[]): number[];
        Decrypt(encryptedData: number[]): number[];
        DecryptToString(encryptedData: number[]): string;
    }
}
declare namespace Calysto.TestTools.UnitTesting {
    namespace Assert {
        /**
         * Test references and types with ===, than
         * Compare values for reference types by serializing to json and compare json strings.
         * @param expected
         * @param actual
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function AreEqual<T>(expected: T, actual: T, message?: string, parameters?: any[] | object): boolean;
        function AreNotEqual<T>(notExpected: T, actual: T, message?: string, parameters?: any[] | object): boolean;
        /**
         * Test with if references and types are equal using ===.
         * Doesn't compare values for reference types.
         * @param expected
         * @param actual
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function AreSame<T>(expected: T, actual: T, message?: string, parameters?: any[] | object): boolean;
        /**
         * Test with if references and types are equal using ===.
         * Doesn't compare values for reference types.
         * @param expected
         * @param actual
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function AreNotSame<T>(expected: T, actual: T, message?: string, parameters?: any[] | object): boolean;
        function Fail(message?: string, parameters?: any[] | object): boolean;
        function Inconclusive(message?: string, parameters?: any[] | object): boolean;
        /**
         * Expects condition to be false.
         * @param condition
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function IsFalse(condition: boolean, message?: string, parameters?: any[] | object): boolean;
        /**
         * Expects condition to be true.
         * @param condition
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function IsTrue(condition: boolean, message?: string, parameters?: any[] | object): boolean;
        /**
         * Is null, undefined or NaN
         * @param value
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function IsNull<T>(value: T, message?: string, parameters?: any[] | object): boolean;
        /**
         * Is not null, undefined or NaN
         * @param value
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function IsNotNull<T>(value: T, message?: string, parameters?: any[] | object): boolean;
        /**
         * Test if action throws exception.
         * @param action function
         * @param message
         * message {prop1} if parameters is object {prop1: "value"}
         * or message {0}, {1} if parameters is array with values ["one", "two"]
         * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
         */
        function ThrowsException<T extends Function>(action: T, message?: string, parameters?: any[] | object): boolean;
    }
}
declare namespace Calysto.TestTools.TestRunner {
    function AddTest(fn: () => void): void;
    function RunTests(): void;
}
declare namespace Calysto {
    class Console {
        private _consoleDiv;
        /** default: 1000 */
        LineMaxLength: number;
        private EnsureCreated;
        ApplyStyle(style: string): void;
        private ConverToString;
        WriteLine(txt: any): void;
        /** Clear console content */
        Clear(): void;
        /** Remove console from DOM */
        Destroy(): void;
        constructor();
        static readonly Current: Console;
    }
}
declare namespace Calysto.CacheProvider {
    /**
     * Set item into storage.
     * @param storage Storage to be used: localStorage or sessionStorage
     * @param key cache key
     * @param item item to be cached
     * @param expirationAfterSeconds
     * @param slidingDurationSeconds item will expire if not used more than x seconds
     */
    function Set<TContent>(storage: Storage, key: string, item: TContent, expirationAfterSeconds?: number, slidingDurationSeconds?: number): void;
    function Get<TContent>(storage: Storage, key: string): TContent;
    function Remove(storage: Storage, key: string): void;
    function Clear(storage: Storage): void;
}
declare namespace Calysto.Mvc.AjaxForm {
    export function IsAjaxFormSubmitEnabled(): boolean;
    export function UseAjaxFormSubmit(enable?: boolean): void;
    /**
     * Submit form without validation.
     * Form has to be fully rendered and visible in browser, otherwise it won't work.
     * @param formSelector
     */
    export function SubmitForm(formSelector: string | ICalystoHtmlFromElement, delay?: number): void;
    interface ICalystoHtmlFromElement extends HTMLFormElement {
        $$CalystoInterceptor: boolean;
    }
    export {};
}
declare namespace Calysto.Mvc {
    class CalystoSpinner {
        private constructor();
        /**
         * Start spinner inside container, execute executor, remove spinner, return result from executor.
         * @param containerSelector
         * @param executor
         */
        static UseSpinnerAsync<TReturn>(containerSelector: string | HTMLElement, executor: () => Promise<TReturn>): Promise<TReturn>;
        /**
        * Search for calysto-spinner elements inside container and use them.
        * Spinner will be removed on first ajax response received.
        * @param containerSelector
        * @param autoRemoval
        */
        static Start(containerSelector: string | HTMLElement, autoRemoval: boolean): CalystoSpinner;
        Remove(): void;
    }
}
declare namespace Calysto.Binding {
    enum TemplateKind {
        NoData = 1,
        Header = 2,
        Footer = 3,
        Separator = 4,
        Item = 5,
        AlternatingItem = 6
    }
}
declare namespace Calysto.Binding.Setup {
    class BindingSetup implements IBindingSetup {
        RootUid: string;
        Bindings: IBindingItem[];
        ViewListeners: IHtmlListeningItem[];
        Repeaters: IRepeaterItem[];
        Templates: ITemplateItem[];
        DataListeners: IDataListeningItem[];
        Sources: ISourceItem[];
    }
    class BindingService {
        private _uid;
        private _setup;
        constructor(uid: string, factory: BindingSetup);
        private GetCsvValues;
        Root(): this;
        /**
         * 2-way binding, 1 to 1
         * @param elementPath single element path, e.g. value, style.backgroundColor, etc.
         * @param dataSourcePath single data source path, e.g. path1.sub1, @.path.sub, path2, path3,...
         * @param jsSetConvert
         *		1. Lambda: (dataSourceValue) => returns value which will be assigned to element property.
         *		2. Data source handler path. Function should accept passed arguments and return value which will be assigned to element property.
         *		3. External func name only. Function should accept passed arguments and return value which will be assigned to element property.
         * @param jsGetConvert
         *		1. Lambda: (elementValue) => returns value which will be assigned to data source property.
         *		2. Data source handler path. Function should accept passed arguments and return value which will be assigned to element property.
         *		3. External func name only. Function should accept passed arguments and return value which will be assigned to element property.
         * @param eventNames
         *		default is 'change', use CSV DOM events names, e.g. mouseover, mouseout, click, input, change
         */
        Bind(elementPath: string | string[], dataSourcePath: string | string[], jsSetConvert?: string | ((context: IDataListenerContext, dsValue: any) => any), jsGetConvert?: string | ((context: IViewListenerContext, elValue: any) => any), eventNames?: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[]): this;
        /**
         * Create listener for data source values.
         * @param dataSourcePaths CSV: path1, @.path2.sub, path3...
         * @param jsHandler
         *		1. Lambda: (context, path1Value, @.path2.subValue, path3Value) => { }
         *		2. Data source handler path. Function should accept passed arguments, e.g. (context, path1Value, @.path2.subValue, path3Value).
         *			This inside is object in which handler function is defined.
         *		3. External func name only. Function should accept passed arguments, e.g. (context, path1Value, @.path2.subValue, path3Value).
         */
        ListenData(dataSourcePaths: string | string[], jsHandler: string | ((context: IDataListenerContext, ...items: any[]) => void | boolean)): this;
        /**
         * Create DOM listener.
         * @param eventNames CSV: name1, name2, name3, ...
         * @param jsHandler
         *		1. Lambda: (context) => { }
         *		2. Data source handler path. Function should accept (context) arguments.
         * 			This inside is object in which handler func is defined.
         *		3. External func name only. Function should accept (context) arguments.
         */
        ListenView(eventNames: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[], jsHandler: string | ((context: IViewListenerContext) => void | boolean)): this;
        /**
         * Create data source path at current element.
         * @param dataSourcePath
         */
        Source(dataSourcePath: string): this;
        Repeater(dataSourcePath: string): this;
        Template(kind: TemplateKind): this;
    }
    export class BindingFactory {
        private _setup;
        GetSetup(): BindingSetup;
        GetRoot(): string;
        Assign(uid: string, action: (item: BindingService) => BindingService): this;
    }
    export {};
}
declare namespace Calysto.Binding.Attributes {
    const ComponentSetting = "calysto-binding-component";
    const Uid = "calysto-binding-uid";
}
declare namespace Calysto.Binding.BindingCache {
    function GetRepeaterSetting(element: BindingElement): BindableRepeater;
    function GetBindingElement(uid: string): ElementSettings;
    function GetElementUid(element: HTMLElement): string;
    function InitializeBindings(rootElement: BindingElement, settings?: IBindingSetup): void;
}
declare namespace Calysto.Binding {
    class BindingDataSource {
        dsListeners: BindingDictionaryTree;
        constructor(dataSource?: any);
        private dataSource;
        SetDataSource(dataSource: any): this;
        GetDataSource<T>(): T;
        SetValue(path: string, value: any, dontNotify?: boolean): this;
        GetValue(path: string): unknown;
        /**
         * SetValue without calling NotifyPropertyChanged.
         * @param dataProperty
         * @param value
         */
        SetValueSilent(dataProperty: string, value: any): this;
        /**
         * SetValue and force call NotifyPropertyChanged, even if new value is the same as the old one.
         * @param dataProperty
         * @param value
         */
        SetValueLoud(dataProperty: string, value: any): this;
        /**
         *
         * @param propertyPath
         * @param listenersArr if not set, will notify all listeners, required for initial binding
         */
        NotifyPropertyChanged(propertyPath: string): this;
    }
}
declare namespace Calysto.Binding {
    export class DataSourceListenerItem {
        Owner: TreeNode;
        Element: BindingElement;
        FullPath: string;
        CallbackFunc: (property: string) => void;
        constructor(Owner: TreeNode, Element: BindingElement, FullPath: string, CallbackFunc: (property: string) => void);
        RemoveListener(): void;
    }
    class TreeNode {
        $$$_fullPath: string;
        $$$_listeners: DataSourceListenerItem[];
        $$$_ownerTree: BindingDictionaryTree;
        /**
         * create tree structure of listeners
        * other properties which are added to current tree node are children and their path contains parent path + their segment
         * @param {string} fullPath
         */
        constructor(ownerTree: BindingDictionaryTree, fullPath: string);
        AddListener(item: DataSourceListenerItem): void;
    }
    export class BindingDictionaryTree {
        private rootNode;
        /**
         * Get tree node by path or create new one if node not found.
         * @param {type} path @ means root, eg. @.level1.level2.level3
         * @returns
         */
        private GetTreeNode;
        AddListener(propertyPath: string, element: BindingElement, callback: (property: string) => void): DataSourceListenerItem;
        private GetListeners;
        /**
         * get listeners from current path and all descendants
         * @param {type} path required, use @ for root
         * @returns
         */
        GetListenersAndDescendants(propertyPath: string): DataSourceListenerItem[];
        private itemsCache;
        InvalidateCache(): void;
        private AddToCache;
        private GetFromCache;
    }
    export {};
}
declare namespace Calysto.Binding {
    /** Single path resolver is created for single element */
    class BindingElementPathResolver {
        private Element;
        private constructor();
        static GetInstance(element: BindingElement): BindingElementPathResolver;
        private _binder;
        private FindDataBinder;
        GetDataBinder(): BindingObservable;
        private ResolveAbsolutePath;
        private _pathCache;
        CreateAbsoluteDataPath(relativePath: string): string;
    }
}
declare namespace Calysto.Binding {
    /**
     * DOM element custom properties: visible, invisible, enabled, disabled
     * Data custom properties inside repeater: DataItem, ItemIndex
     *
    */
    class BindingObservable extends BindingDataSource {
        constructor();
        private WriteLog;
        private SetElementValue;
        /**
         * Remove element from DOM, remove listeners from ObservableDictionaryTree
         * @param element
         */
        private RemoveElementAndListeners;
        private CloneNodeSafe;
        private BindDataToRepeater;
        private GetUpperPath;
        /**
         * 1. test if lambda
         * 2. test if exists in window
         * 3. search in dataSource
         * @param absoluteDataPath
         */
        private ResolveHandlerFunction;
        private CreateHtmlEventContext;
        private CreateViewListeners;
        private _cachedDataSourceTypes;
        private CreateDataSourceContext;
        private GetDataSourceValue;
        private CreateDataListeners;
        /** HTMLElement holding ObservableBinder */
        private _rootElement;
        private EnsureRootElement;
        private _recursions;
        NotifyPropertyChanged(propertyPath: string): this;
        private _rootSelector;
        SetRootElement(calystoSelector: any): this;
        private _factory;
        SetFactory(factory: Setup.BindingFactory): this;
        DataBind(): this;
    }
}
declare namespace Calysto.Web {
    class CalystoVirtualPathHelper {
        private _path;
        constructor(path: string);
        private _appRelative;
        ToAppRelativeUrlPath(): string;
        private _virtualPath;
        ToVirtualUrlPath(): string;
        private static CreateAppRelativePath;
        private static CombineToVirtualPath;
        private static GetBasePath;
    }
}
declare namespace Calysto.DataAnnotations.Validators {
    function GetValidators(sender: IValidationElement, context: IValidationContext): IValidator[];
}
declare namespace Calysto.DataAnnotations {
    export interface IValidator {
        ErrorText: string;
        IsValid: (value: any) => boolean;
    }
    export interface IValidationElement extends HTMLInputElement {
        $$validationInitialized: boolean;
        $$validationContainer: HTMLFormElement;
        $$validationValidators: IValidator[];
        $$validationContext: IValidationContext;
    }
    interface ErrorMessage {
        /** full path Prop1.Prop2.Prop3 */
        FormsNamePath: string;
        ErrorText: string;
    }
    export interface IValidationContext {
        inputsArr: IValidationElement[];
        form: HTMLFormElement;
        /** input, textarea, select elements for validation */
        inputs: {
            [name: string]: IValidationElement;
        };
        /** placeholders for error messages */
        spans: {
            [name: string]: HTMLSpanElement;
        };
        /** summary div element */
        summary: HTMLDivElement[];
        /** current errors */
        errors: ErrorMessage[];
        isInteractive: boolean;
    }
    class CalystoValidationService {
        readonly Context: IValidationContext;
        constructor(Context: IValidationContext);
        /** validate form */
        Validate(): this;
        /** Render errors */
        Render(): this;
        HasErrors(): boolean;
        /**
         * If enabled, will validate during text entering.
         * If not enabled, will validate before form submit only.
         * @param enable
         */
        Interactive(enable: boolean): this;
    }
    /**
    * Find parent form and create new CalystoValidationService where form is container.
    * Returns null if client side validation is not enabled.
    * @param element
    */
    export function FindValidationService(element: HTMLElement): CalystoValidationService;
    export function UseValidationService(containerSelector: string | HTMLElement): CalystoValidationService;
    export {};
}
declare namespace Calysto.Web.UI.Direct {
    enum Kind {
        Message = 0,
        Error = 1,
        Warning = 2,
        Success = 3,
        Info = 4
    }
    class CalystoHtmlBuilder {
        private _messages;
        AddMessage(kind: keyof typeof Kind, text: string): this;
        private GetMessagesTags;
        private GetHtmlElements;
        HasElements(): boolean;
        /**
         * Create parentTag element and add items as children.
         * @param parentTag
         * @param parentClass
         */
        ToHtml(): string;
    }
}
declare namespace Calysto.Web.UI.Direct {
    class CalystoMvcModelState<TModel> {
        Raw: TModel;
        RootSelector: string | HTMLFormElement;
        Errors: Calysto.KeyValue<string, string>[];
        Values: Calysto.KeyValue<string, string>[];
        /**
         * ctor is used in C# CalystoMvcModelState.ToJavaScript()
         * @param raw
         * @param rootSelector
         * @param errors
         * @param values
         */
        constructor(raw?: TModel, rootSelector?: string | HTMLFormElement, errors?: KeyValue<string, string>[], values?: KeyValue<string, string>[]);
        AddError<TValue>(pathExpression: (m: TModel) => TValue, errorMsg: string): void;
        SetValue<TValue>(pathExpression: (m: TModel) => TValue, value: TValue): void;
        /**
         * Query DOM elements by attribute name=pathExpression.
         * @param pathExpression
         */
        Query<TValue>(pathExpression: (m: TModel) => TValue): DomQuery<HTMLElement>;
        private UseDirectQuery;
        private ClearErrors;
        private RenderErrors;
        private RenderValues;
        Render(): void;
    }
}
declare namespace Calysto.WebView {
    abstract class HostObjectBase {
        protected _hostObjectName: string;
        protected InvokeMethodAsync(methodName: string, args?: any[]): Promise<any>;
    }
}
declare namespace Calysto.WebControls {
    class CalystoScroller {
        /** scrollbar min opacity, 0 - 100 */
        MinOpacity: number;
        /** scrollbar max opacity, 0 - 100 */
        MaxOpacity: number;
        private _currentTop;
        /** current top position (negative number) */
        get CurrentTop(): number;
        set CurrentTop(value: number);
        private _currentLeft;
        /** current left position (negative number) */
        get CurrentLeft(): number;
        set CurrentLeft(value: number);
        private firstInitDone;
        private contentEl;
        private mainEl;
        private contentElWidth;
        private contentElHeight;
        private mainElWidth;
        private mainElHeight;
        private hSliderEl;
        private hMarkerEl;
        private hAR;
        private showHorizontal;
        private vSliderEl;
        private vMarkerEl;
        private vAR;
        private showVertical;
        private maxMarkerLeft;
        private maxMarkerTop;
        private accelerationAbort;
        private moveStatistics;
        private markerDragging;
        private startCondition;
        private minContentTop;
        private minContentLeft;
        constructor(mainElement: HTMLElement);
        private ScrollersAdjustContent;
        private SetScrollPosition;
        private WheelAdjustSliderX;
        private WheelAdjustSliderY;
        private WheelAdjustSliders;
        /**
         *
         * @param sender
         * @param velocity pixel/second
         * @param isAxisY
         */
        private CreateAnimator;
        private CalculateVelocity;
        private HandleAcceleration;
        private InitElements;
        private CopyEvent;
        private InitializeEvents;
        Start(): void;
        /**
        * Initialize calystoScroller. If content or container are resized, scroller is refreshed every 1 second.
        * @param selector if not provided, will select all elements with class calystoScroller
        */
        static Create(selector?: any): void;
    }
}
declare namespace Calysto.WebControls.CalystoTable {
    function MakeSortable(tableSlector: any): void;
}
declare namespace Calysto.Tasks {
}
declare namespace Calysto.Tasks {
}
declare namespace Calysto.Tasks {
}
