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

  DONE_ITEM = gql`
    mutation DoneItem($itemId: Int!) {
      doneItem(itemId: $itemId)
    }
  `;

  constructor(private apollo: Apollo) { }

  ngOnInit(): void {
    this.apollo.watchQuery({
      query: gql`{
        lists {
          name
          itemDatas {
            id
            title
            description
            done
          }
        }
      }`
    })
      .valueChanges.subscribe((result: any) => {
        this.lists = result.data?.lists
        this.loading = result.loading;
        this.error = result.error;
      });
  }

  protected onChecked(itemId: number) {
    this.apollo
      .mutate({
        mutation: this.DONE_ITEM,
        variables: {
          itemId
        },
      })
      .subscribe();
  }
}
