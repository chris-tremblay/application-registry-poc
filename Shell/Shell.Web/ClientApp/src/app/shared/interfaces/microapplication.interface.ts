export interface IMicroApplication {
    fqan: string;
    appElementName: string;
    widgetNames?: string[];
    scriptUrls: string[];
    styleUrls?: string[];
    configuration?: any;
}
