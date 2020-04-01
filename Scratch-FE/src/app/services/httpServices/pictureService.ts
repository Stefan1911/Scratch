import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LOADIPHLPAPI } from 'dns';

@Injectable({
	providedIn: 'root'
})
export class PictureService {

    constructor(private http : HttpClient) { }

    uploadImage(image : File) {        
        const uploadData = new FormData();
        uploadData.append('file', image, image.name);
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');
        return this.http.post('http://localhost:5000/api/Image', uploadData, {
            headers: headers
        });
      }
}