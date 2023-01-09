import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
})
export class DetailComponent implements OnInit {
  constructor(
    private appServivc: AppService,
    private _activatedRoute: ActivatedRoute
  ) {
  }
  item: any;
  id: any = '';

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => this.id = params['id']);

    this.appServivc.getAll().subscribe((res: any[]) => {
      this.item = res.find(x => x.id === +this.id);
    })
  }
}
