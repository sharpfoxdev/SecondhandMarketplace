export interface AddImageRequest {
    file: File;
    listingId: string;
}

export interface Image {
    id: string;
    imageUrl: string;
    fileName: string;
    fileExtension: string;
    fileSizeInBytes: number;
}
