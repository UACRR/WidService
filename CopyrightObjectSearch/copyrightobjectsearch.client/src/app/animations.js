"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.fadeIn = exports.slideInOut = void 0;
var animations_1 = require("@angular/animations");
exports.slideInOut = animations_1.trigger('slideInOut', [
    animations_1.transition(':enter', [
        animations_1.style({ height: '0px', overflow: 'hidden' }),
        animations_1.animate('200ms ease-in', animations_1.style({ height: '100px' }))
    ]),
    animations_1.transition(':leave', [
        animations_1.animate('200ms ease-in', animations_1.style({ height: '0px', overflow: 'hidden' }))
    ])
]);
exports.fadeIn = animations_1.trigger('fadeIn', [
    animations_1.transition(':enter', [
        animations_1.style({ opacity: '0' }),
        animations_1.animate('200ms ease-in', animations_1.style({ opacity: '0.1' }))
    ]),
    animations_1.transition(':leave', [
        animations_1.animate('200ms ease-in', animations_1.style({ opacity: '0.1' }))
    ])
]);
//# sourceMappingURL=animations.js.map