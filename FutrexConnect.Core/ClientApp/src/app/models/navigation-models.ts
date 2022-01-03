export interface IBreadcrumbData {
  title: String;
  url: String;
  iconUrl: String;
  isActive: Boolean;
}

export interface IPageNavigationData {
  title: String;
  breadcrumbs: IBreadcrumbData[];
}
