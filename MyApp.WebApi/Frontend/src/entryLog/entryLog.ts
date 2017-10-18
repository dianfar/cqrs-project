export interface IEntryLog {
    id: string,
    userId: string,
    projectId: string,
    projectName: string,
    hours: number,
    entryDate: Date,
    description: string
}