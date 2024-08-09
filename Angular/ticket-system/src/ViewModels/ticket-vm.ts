export interface TicketVm{
    id: number;
    creationDateTime: Date;
    phoneNumber: string;
    governorate: string;
    city: string;
    district: string;
    isHandled: boolean;
}