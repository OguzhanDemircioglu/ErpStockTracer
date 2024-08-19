export class MenuModel {
  name: string = "";
  icon: string = "";
  url: string = "";
  isTitle: boolean = false;
  subMenus: MenuModel[] = [];
}

export const Menus: MenuModel[] = [
  {
    name: "Anasayfa",
    icon: "fas fa-solid fa-home",
    url: "/",
    isTitle: false,
    subMenus: []
  },
  {
    name: "Ana Group",
    icon: "far fa-solid fa-trowel-bricks",
    url: "/",
    isTitle: false,
    subMenus: [
      {
        name: "Müşteriler",
        icon: "far fa-solid fa-users",
        url: "/Customers",
        isTitle: false,
        subMenus: []
      },
      {
        name: "Depolar",
        icon: "far fa-solid fa-warehouse",
        url: "/Depots",
        isTitle: false,
        subMenus: []
      }, {
        name: "Ürünler",
        icon: "far fa-solid fa-boxes-stacked",
        url: "/Products",
        isTitle: false,
        subMenus: []
      }, {
        name: "Reçeteler",
        icon: "far fa-solid fa-boxes-packing",
        url: "/Recipes",
        isTitle: false,
        subMenus: []
      }
    ]
  },
  {
    name: "Siparişler",
    icon: "far fa-solid fa-truck",
    url: "/Orders",
    isTitle: false,
    subMenus: []
  },
  {
    name: "Faturalar",
    icon: "far fa-solid fa-file-invoice",
    url: "/",
    isTitle: false,
    subMenus: [
      {
        name: "Alış Faturaları",
        icon: "far fa-solid fa-file-invoice",
        url: "/invoices/purchase",
        isTitle: false,
        subMenus: []
      },
      {
        name: "Satış Faturaları",
        icon: "far fa-solid fa-file-invoice",
        url: "/invoices/selling",
        isTitle: false,
        subMenus: []
      }
    ]
  },
]

