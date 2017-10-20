import axios from "axios";
import { IEntryLog } from "./EntryLog";

export class EntryLogStore {
    async getEntryLogs(): Promise<IEntryLog[]> {
        let response = await axios.get("/api/entryLogs");
        let logs = response.data as IEntryLog[];
        return logs;
    }

    async getEntryLog(id: string): Promise<IEntryLog> {
        let response = await axios.get(`/api/entryLogs/${id}`);
        let log = response.data as IEntryLog;
        return log;
    }

    async updateEntryLog(entryLog: IEntryLog): Promise<void> {
        await axios.put(`/api/entryLogs`, entryLog);
    }

    async addEntryLog(entryLog: IEntryLog): Promise<void> {
        await axios.post(`/api/entryLogs`, entryLog);
    }
}

const entryLogStore = new EntryLogStore();

export default entryLogStore;