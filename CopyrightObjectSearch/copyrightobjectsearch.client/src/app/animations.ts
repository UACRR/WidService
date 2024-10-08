import { animate, style, transition, trigger } from "@angular/animations";

export const slideInOut =
  trigger('slideInOut', [
    transition(':enter', [
      style({ height: '0px', overflow: 'hidden' }),
      animate('200ms ease-in', style({ height: '100px' }))
    ]),
    transition(':leave', [
      animate('200ms ease-in', style({ height: '0px', overflow: 'hidden' }))
    ])
  ]);

  export const slideIn =
  trigger('slideInOut', [
    transition(':enter', [
      style({ height: '0px', overflow: 'hidden' }),
      animate('200ms ease-in', style({ height: '100px' }))
    ]),
  ]);

  export const slideOut =
  trigger('slideInOut', [
    transition(':leave', [
      animate('200ms ease-in', style({ height: '0px', overflow: 'hidden' }))
    ])
  ]);

export const fadeIn =
  trigger('fadeIn', [
    transition(':enter', [
      style({ opacity: '0' }),
      animate('200ms ease-in-out', style({ opacity: '0.1' }))
    ]),
    transition(':leave', [
      animate('200ms ease-in-out', style({ opacity: '0.1' }))
    ])
  ]);

