import { IPageNavigationData } from './models/navigation-models';
import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, ActivatedRoute } from '@angular/router';
import { debounceTime, filter, take } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'Futrex Connect Core';
  pageNavigationData: IPageNavigationData;
  constructor(private _router: Router, private _route: ActivatedRoute) {
    this.pageNavigationData = { title: '', breadcrumbs: [] };
  }
  ngOnInit() {
    this._router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((x: NavigationEnd) => {
        var root = this._route.root.firstChild;
        this.pageNavigationData.breadcrumbs = [];
        while (root) {
          if (root.snapshot.data.parent) {
            this.pageNavigationData.breadcrumbs.push({
              title: root.snapshot.data.parent.title,
              iconUrl: root.snapshot.data.parent.iconUrl,
              url: root.snapshot.url.join('/'),
              isActive: false,
            });
          }
          this.pageNavigationData.breadcrumbs.push({
            title: root.snapshot.data.title,
            iconUrl: '',
            url: root.snapshot.url.join('/'),
            isActive: false,
          });
          root = root.firstChild;
        }

        if (this.pageNavigationData.breadcrumbs.length > 0)
          this.pageNavigationData.breadcrumbs[
            this.pageNavigationData.breadcrumbs.length - 1
          ].isActive = true;
      });
  }
}
