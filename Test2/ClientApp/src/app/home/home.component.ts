import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(
    private appService: AppService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.appService.getAll().subscribe((res) => {
      this.employeeList = res;
    })
  }

  onClickDetail(item: any){
    this.router.navigate(['/detail'], { queryParams: { id: item.id } })
  }

  employeeList: any[] = [
  ];
}
