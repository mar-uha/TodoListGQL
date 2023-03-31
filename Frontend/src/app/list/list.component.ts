import { Component, OnInit } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.sass']
})
export class ListComponent implements OnInit {
  
  loading = true;
  error: any;
  lists: any[] = [];

  constructor(private apollo: Apollo) {}

  ngOnInit(): void {
    this.apollo.watchQuery({
      query: gql`{
        lists {
          name
          itemDatas {
            title
            description
            done
          }
        }
      }`
    })
    .valueChanges.subscribe((result: any) => {
      console.log(result);
      this.lists = result.data?.lists
      this.loading = result.loading;
      this.error = result.error;
    });
  }
}
