export interface IElementRegistryService {
    /** Ensures scripts and styles for the given custom-element are loaded. */
    prepare(name: string): Promise<any>;
    baseUrlFor(applicationName: string): string;
}
