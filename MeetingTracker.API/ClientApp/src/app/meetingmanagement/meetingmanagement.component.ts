import { Component } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'

@Component({
  selector: 'meetingmanagement-component',
  templateUrl: './meetingmanagement.component.html'
})
export class MeetingManagementComponent {
  public progress: number;
  public talks: string[];
  constructor(private http: HttpClient) { }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', `api/meetingmanagement`, formData, {
      reportProgress: true,
    });

    this.http.request<string[]>(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
      {
        this.talks = event.body;
      }
       
    });
  }
}
