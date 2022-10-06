export class Subdetail {
   public id!: number;
   public memberId!: string;
    public memberLocation!: string;
    public prescriptionId!: number;
    public refillOccurrence!: string;
    public status!: boolean;
    public subscriptionDate!:Date; 
constructor(
    id: number,
    memberId: string,
    memberLocation: string,
    prescriptionId: number,
    refillOccurrence: string,
    status: boolean,
    subscriptionDate:Date,){}

}
