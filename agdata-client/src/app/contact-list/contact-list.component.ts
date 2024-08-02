import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Contact } from 'src/models/contact.model';
import { ContactService } from 'src/services/contact.service';
import { ContactFormComponent } from '../contact-form/contact-form.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: MatTableDataSource<Contact> = new MatTableDataSource<Contact>();
  searchTerm: string = '';
  displayedColumns: string[] = ['id','name', 'address', 'actions'];

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;

  constructor(public dialog: MatDialog, private contactService: ContactService) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.contactService.getContacts().subscribe((contacts: Contact[]) => {
      this.contacts = new MatTableDataSource(contacts);
      if(this.paginator)
        this.contacts.paginator = this.paginator;
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ContactFormComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadContacts();
      }
    });
  }

  editContact(contact: Contact): void {
    const dialogRef = this.dialog.open(ContactFormComponent, {
      width: '400px',
      data: contact
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadContacts();
      }
    });
  }

  deleteContact(id: number): void {
    this.contactService.deleteContact(id).subscribe(() => {
      this.loadContacts();
    });
  }
}