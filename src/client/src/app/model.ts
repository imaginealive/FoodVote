export class Account {
    constructor(
      public id: string,
      public username: string,
      public createAt: Date
    ) { }
  }

export class PollRequest {
    constructor(
        public ShopName: string,
        public MenuName: string,
        public CreateBy: string
    ) { }
}

export class PollInfo {
    constructor(
        public id: string,
        public ShopName: string,
        public CreateBy: string,
        public createAt: Date,
        public isClose: boolean,
        public menus: Menus[],
        public unvoter: string[]
    ) { }
}

export class Menus {
    constructor(
        public id: string,
        public menuName: string,
        public isDefault: boolean,
        public voter: string[],
    ) { }
}
