export class User {
    id: number;
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    roles: string[]; // Assuming roles is an array of strings
  
    constructor(data: any) {
      this.id = data.id;
      this.firstName = data.firstName;
      this.lastName = data.lastName;
      this.userName = data.userName;
      this.email = data.email;
      this.roles = data.roles || [];
    }
  }
  