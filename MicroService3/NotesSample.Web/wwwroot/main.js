(window["wpJsonpNotesSample"] = window["wpJsonpNotesSample"] || []).push([["main"],{

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/composed-widget/composed-widget.component.html":
/*!******************************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/composed-widget/composed-widget.component.html ***!
  \******************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<p>composed widget Example</p>\n\n<mnc-members-member-detail-view></mnc-members-member-detail-view>\n<mnc-notes-state-selector></mnc-notes-state-selector>");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/empty/empty.component.html":
/*!**********************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/empty/empty.component.html ***!
  \**********************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/mnc-notes.component.html":
/*!********************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/mnc-notes.component.html ***!
  \********************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"mnc-notes\">\r\n  <h1>Notes Application Loaded from App Registry</h1>\r\n  \r\n  <router-outlet></router-outlet>\r\n</div>");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/state-selector/state-selector.component.html":
/*!****************************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/state-selector/state-selector.component.html ***!
  \****************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<select (change)=\"selectState($event)\">\n    <option *ngFor=\"let state of states\">{{state}}</option>\n</select>");

/***/ }),

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/composed-widget/composed-widget.component.css":
/*!***************************************************************!*\
  !*** ./src/app/composed-widget/composed-widget.component.css ***!
  \***************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvc2VkLXdpZGdldC9jb21wb3NlZC13aWRnZXQuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "./src/app/composed-widget/composed-widget.component.ts":
/*!**************************************************************!*\
  !*** ./src/app/composed-widget/composed-widget.component.ts ***!
  \**************************************************************/
/*! exports provided: ComposedWidgetComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ComposedWidgetComponent", function() { return ComposedWidgetComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};

let ComposedWidgetComponent = class ComposedWidgetComponent {
    constructor() { }
    ngOnInit() {
    }
};
ComposedWidgetComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'mnc-notes-composed-widget',
        template: __importDefault(__webpack_require__(/*! raw-loader!./composed-widget.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/composed-widget/composed-widget.component.html")).default,
        styles: [__importDefault(__webpack_require__(/*! ./composed-widget.component.css */ "./src/app/composed-widget/composed-widget.component.css")).default]
    }),
    __metadata("design:paramtypes", [])
], ComposedWidgetComponent);



/***/ }),

/***/ "./src/app/empty/empty.component.css":
/*!*******************************************!*\
  !*** ./src/app/empty/empty.component.css ***!
  \*******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2VtcHR5L2VtcHR5LmNvbXBvbmVudC5jc3MifQ== */");

/***/ }),

/***/ "./src/app/empty/empty.component.ts":
/*!******************************************!*\
  !*** ./src/app/empty/empty.component.ts ***!
  \******************************************/
/*! exports provided: EmptyComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EmptyComponent", function() { return EmptyComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};

let EmptyComponent = class EmptyComponent {
    constructor() { }
    ngOnInit() {
    }
};
EmptyComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'mnc-notes-empty',
        template: __importDefault(__webpack_require__(/*! raw-loader!./empty.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/empty/empty.component.html")).default,
        styles: [__importDefault(__webpack_require__(/*! ./empty.component.css */ "./src/app/empty/empty.component.css")).default]
    }),
    __metadata("design:paramtypes", [])
], EmptyComponent);



/***/ }),

/***/ "./src/app/mnc-notes.component.ts":
/*!****************************************!*\
  !*** ./src/app/mnc-notes.component.ts ***!
  \****************************************/
/*! exports provided: MncNotesAppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MncNotesAppComponent", function() { return MncNotesAppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};

let MncNotesAppComponent = class MncNotesAppComponent {
    constructor() {
        this.title = 'app';
        // constructor(
        //   private readonly router: Router,
        // ) {
        // }
        // ngOnInit(): void { }
        // ngAfterViewInit(): void {
        //   this.router.initialNavigation();
        // }
    }
};
MncNotesAppComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'mnc-notes',
        template: __importDefault(__webpack_require__(/*! raw-loader!./mnc-notes.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/mnc-notes.component.html")).default
    })
], MncNotesAppComponent);



/***/ }),

/***/ "./src/app/mnc-notes.module.ts":
/*!*************************************!*\
  !*** ./src/app/mnc-notes.module.ts ***!
  \*************************************/
/*! exports provided: MncNotesAppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MncNotesAppModule", function() { return MncNotesAppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var _mnc_notes_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./mnc-notes.component */ "./src/app/mnc-notes.component.ts");
/* harmony import */ var _state_selector_state_selector_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./state-selector/state-selector.component */ "./src/app/state-selector/state-selector.component.ts");
/* harmony import */ var _angular_elements__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/elements */ "./node_modules/@angular/elements/fesm2015/elements.js");
/* harmony import */ var _composed_widget_composed_widget_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./composed-widget/composed-widget.component */ "./src/app/composed-widget/composed-widget.component.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _empty_empty_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./empty/empty.component */ "./src/app/empty/empty.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};










const routes = [
    { path: '**', component: _empty_empty_component__WEBPACK_IMPORTED_MODULE_9__["EmptyComponent"] }
];
let MncNotesAppModule = class MncNotesAppModule {
    constructor(injector) {
        this.injector = injector;
        customElements.define('mnc-notes', Object(_angular_elements__WEBPACK_IMPORTED_MODULE_6__["createCustomElement"])(_mnc_notes_component__WEBPACK_IMPORTED_MODULE_4__["MncNotesAppComponent"], { injector }));
        customElements.define('mnc-notes-state-selector', Object(_angular_elements__WEBPACK_IMPORTED_MODULE_6__["createCustomElement"])(_state_selector_state_selector_component__WEBPACK_IMPORTED_MODULE_5__["StateSelectorComponent"], { injector }));
        customElements.define('mnc-notes-composed-widget', Object(_angular_elements__WEBPACK_IMPORTED_MODULE_6__["createCustomElement"])(_composed_widget_composed_widget_component__WEBPACK_IMPORTED_MODULE_7__["ComposedWidgetComponent"], { injector }));
    }
};
MncNotesAppModule.ctorParameters = () => [
    { type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Injector"] }
];
MncNotesAppModule = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [
            _mnc_notes_component__WEBPACK_IMPORTED_MODULE_4__["MncNotesAppComponent"],
            _state_selector_state_selector_component__WEBPACK_IMPORTED_MODULE_5__["StateSelectorComponent"],
            _composed_widget_composed_widget_component__WEBPACK_IMPORTED_MODULE_7__["ComposedWidgetComponent"],
            _empty_empty_component__WEBPACK_IMPORTED_MODULE_9__["EmptyComponent"]
        ],
        imports: [
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"].withServerTransition({ appId: 'ng-cli-universal' }),
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
            _angular_router__WEBPACK_IMPORTED_MODULE_8__["RouterModule"].forRoot(routes, { useHash: true }),
        ],
        providers: [],
        bootstrap: [
            _state_selector_state_selector_component__WEBPACK_IMPORTED_MODULE_5__["StateSelectorComponent"],
            _composed_widget_composed_widget_component__WEBPACK_IMPORTED_MODULE_7__["ComposedWidgetComponent"]
        ],
        entryComponents: [_mnc_notes_component__WEBPACK_IMPORTED_MODULE_4__["MncNotesAppComponent"]],
        schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["CUSTOM_ELEMENTS_SCHEMA"]]
    }),
    __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injector"]])
], MncNotesAppModule);



/***/ }),

/***/ "./src/app/state-selector/state-selector.component.css":
/*!*************************************************************!*\
  !*** ./src/app/state-selector/state-selector.component.css ***!
  \*************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3N0YXRlLXNlbGVjdG9yL3N0YXRlLXNlbGVjdG9yLmNvbXBvbmVudC5jc3MifQ== */");

/***/ }),

/***/ "./src/app/state-selector/state-selector.component.ts":
/*!************************************************************!*\
  !*** ./src/app/state-selector/state-selector.component.ts ***!
  \************************************************************/
/*! exports provided: StateSelectorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StateSelectorComponent", function() { return StateSelectorComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _state_selector_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./state-selector.service */ "./src/app/state-selector/state-selector.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};


let StateSelectorComponent = class StateSelectorComponent {
    constructor(service, element) {
        this.service = service;
        this.element = element;
        this.country = 'United States';
        this.stateSelected = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    ngOnInit() {
        this.service.loadStates().then(states => this.states = states);
    }
    selectState(event) {
        this.stateSelected.emit(event.target.value);
        // this.element.nativeElement
        //   .dispatchEvent(new CustomEvent('onchanged', {
        //     detail: event.target.value,
        //     bubbles: true
        //   }));
    }
};
StateSelectorComponent.ctorParameters = () => [
    { type: _state_selector_service__WEBPACK_IMPORTED_MODULE_1__["StateSelectorService"] },
    { type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"] }
];
__decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])('country'),
    __metadata("design:type", Object)
], StateSelectorComponent.prototype, "country", void 0);
__decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])('stateSelected'),
    __metadata("design:type", Object)
], StateSelectorComponent.prototype, "stateSelected", void 0);
StateSelectorComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'mnc-notes-state-selector-angular',
        template: __importDefault(__webpack_require__(/*! raw-loader!./state-selector.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/state-selector/state-selector.component.html")).default,
        styles: [__importDefault(__webpack_require__(/*! ./state-selector.component.css */ "./src/app/state-selector/state-selector.component.css")).default]
    }),
    __metadata("design:paramtypes", [_state_selector_service__WEBPACK_IMPORTED_MODULE_1__["StateSelectorService"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ElementRef"]])
], StateSelectorComponent);



/***/ }),

/***/ "./src/app/state-selector/state-selector.service.ts":
/*!**********************************************************!*\
  !*** ./src/app/state-selector/state-selector.service.ts ***!
  \**********************************************************/
/*! exports provided: StateSelectorService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StateSelectorService", function() { return StateSelectorService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};


let StateSelectorService = class StateSelectorService {
    constructor(http) {
        this.http = http;
        this.baseUrl = 'http://localhost:45265';
    }
    loadStates() {
        return this.http.get(`${this.baseUrl}/states`).toPromise();
    }
};
StateSelectorService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
];
StateSelectorService = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
    }),
    __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
], StateSelectorService);



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};
const environment = {
    production: false
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! exports provided: getBaseUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm2015/platform-browser-dynamic.js");
/* harmony import */ var _app_mnc_notes_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/mnc-notes.module */ "./src/app/mnc-notes.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};




function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
const providers = [
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];
if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])(providers).bootstrapModule(_app_mnc_notes_module__WEBPACK_IMPORTED_MODULE_2__["MncNotesAppModule"])
    .catch(err => console.log(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! D:\github\application-registry-poc\MicroService3\NotesSample.Web\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map