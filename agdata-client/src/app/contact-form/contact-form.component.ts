import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ContactService } from './../../services/contact.service';
import { Contact } from 'src/models/contact.model';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {
  contactForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    public dialogRef: MatDialogRef<ContactFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Contact
  ) {}

  ngOnInit(): void {
    this.contactForm = this.fb.group({
      id: [this.data ? this.data.id : -1],
      name: [this.data ? this.data.name : '', Validators.required],
      address: [this.data ? this.data.address : '', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      debugger;
      const contact = this.contactForm.value;
      if (this.data) {
        this.contactService.updateContact(contact).subscribe(() => {
          this.dialogRef.close(true);
        });
      } else {
        this.contactService.addContact(contact).subscribe(() => {
          this.dialogRef.close(true);
        });
      }
    }
  }
}
