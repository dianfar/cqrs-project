import { IObservableArray, observable } from "mobx";
import axios from "axios";
import { IProject } from "./interface";

export class ProjectStore {
    async getProjects(): Promise<IProject[]> {
        let response = await axios.get("/api/projects");
        let projects = response.data as IProject[];
        return projects;
    }

    async getProject(projectId: string): Promise<IProject> {
        let response = await axios.get(`/api/projects/${projectId}`);
        let project = response.data as IProject;
        return project;
    }

    async updateProject(project: IProject): Promise<void> {
        await axios.put(`/api/projects/`, project);
    }

    async addProject(project: IProject): Promise<void> {
        await axios.post(`/api/projects/`, project);
    }

    async deleteProject(projectId: string): Promise<void> {
        await axios.delete(`/api/projects/${projectId}`);
    }
}

const projectStore = new ProjectStore();

export default projectStore;