/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { NewTransactionsComponent } from './newtransactions.component';

let component: NewTransactionsComponent;
let fixture: ComponentFixture<NewTransactionsComponent>;

describe('newtransactions component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
          declarations: [NewTransactionsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
      fixture = TestBed.createComponent(NewTransactionsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
